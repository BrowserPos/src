using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlPos.Lib
{
    public interface IExternalAdapter
    {

        object requestAPI(string url, string jsonArg);
        object API(string className, string method, object arg);
    }
}
