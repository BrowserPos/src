using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlPos.Lib.ClassLib.Controller
{
    /// <summary>
    /// 控制器的基类
    /// </summary>
    public abstract class BaseController : IController
    {
        public JsonResult Json(object obj)
        {
            return new JsonResult { data = obj };
        }

        public bool matchUrl(string url)
        {
            var match = url.Split('/');
            return false;
        }
    }
}
