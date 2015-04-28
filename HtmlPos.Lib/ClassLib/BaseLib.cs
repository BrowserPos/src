using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace HtmlPos.Lib.ClassLib
{
    /// <summary>
    /// 所有服务类的基类,提供一些必要的方法支持 
    /// </summary>
    public class BaseLib
    {
        public static string SuccessToJson(object obj)
        {
            var s = new restJson { status = true, data = obj };
            return Newtonsoft.Json.JsonConvert.SerializeObject(s);
        }
        public static string FailedToJson(object msg)
        {
            var s = new restJson { status = false, msg = msg == null ? "" : msg.ToString() };
            return Newtonsoft.Json.JsonConvert.SerializeObject(s);
        }
    }
    
    /// <summary>
    /// 前台接收数据的格式
    /// </summary>
    public class restJson
    {
        public bool status { get; set; }
        public object data { get; set; }
        public string msg { get; set; }
    }
}
