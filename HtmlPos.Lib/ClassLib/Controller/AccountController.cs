using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlPos.Lib.ClassLib.Controller
{
    public class AccountController:BaseController
    {
        public ActionResult GetUser(object arg)
        {
            return Json(new Version(100, 200, 100, 10));
        }

        public string List(int id,string name)
        {
            System.Threading.Thread.Sleep(1000);
            return name;
        }
    }
}
