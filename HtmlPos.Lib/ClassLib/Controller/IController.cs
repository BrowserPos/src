using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlPos.Lib.ClassLib.Controller
{
   public interface IController
    {
        bool matchUrl(string url);
    }
}
