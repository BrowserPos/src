using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlPos.Lib.ClassLib.Controller
{
    public class SystemController : BaseController
    {
        public ActionResult GetSystemInfo()
        {
            var sf =new {
                     Environment.MachineName,
                     Environment.OSVersion.VersionString,Environment.ProcessorCount,Environment.UserName,Environment.Version,Environment.WorkingSet
                   };
            return Json(sf);
        }

        public ActionResult GetComputerName()
        {
            return Json(Environment.MachineName);
        }
    }
}
