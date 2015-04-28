using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using HtmlPos.Lib.ClassLib;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
namespace HtmlPos.Lib
{
    [ComVisible(true)]

    public class ExternalAdapter : IExternalAdapter
    {
        public EventHandler ApplicationExit;
        public ExternalAdapter(Form form)
        {
            this._mainForm = form;
        }
        Form _mainForm = null;

        public object API(string className, string method, object arg)
        {
            if (className.Equals("Application", StringComparison.OrdinalIgnoreCase))
            {
                switch (method)
                {
                    case "exit":
                        if (ApplicationExit != null)
                        {
                            ApplicationExit(this , EventArgs.Empty);
                        }
                        break;
                    case "windows_size":
                        return Newtonsoft.Json.JsonConvert.SerializeObject(this._mainForm.Size);
                    default:
                        break;
                }
            }
            return 0;
        }
        /// <summary>
        /// 请求MVC
        /// </summary>
        /// <param name="url">控制器+方法(account/getuser)</param>
        /// <param name="jsonArg">方法的参数</param>
        /// <returns>返回JSON格式的数据</returns>
        public object requestAPI(string url, string jsonArg)
        {
            var instance = ClassLib.Factory.GetController(url);
            try
            {
                if (instance == null)
                    throw new Exception("没有找到对应的控制器类!");
                var method = instance.GetType().GetMethod(url.Split('/')[1], BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                if (method == null)
                    throw new Exception("没有找到对应的方法!");
                //进行参数名绑定,与JSON对象的一级属性绑定,并且自动转换参数类型(务必保证参数类型一致)
                //TODO:添加信息缓存功能
                var parameters = method.GetParameters();
                var args = new List<object>();
                if (parameters.Length > 0)
                {
                    var argJson = JObject.Parse(jsonArg);
                    foreach (var p in parameters)
                    {
                        JToken value = null;
                        argJson.TryGetValue(p.Name, out value);
                        args.Add(value == null ? null : value.ToObject(p.ParameterType));
                    }
                }
                //todo:添加过滤的执行接口
                var result = method.Invoke(instance, args.ToArray());
                var ar = result as ClassLib.ActionResult;
                return BaseLib.SuccessToJson(ar != null ? ar.Response() : result);
            }
            catch (Exception ex)
            {
                return BaseLib.FailedToJson(ex.Message);
            }
        }
    }
}
