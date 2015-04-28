using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HtmlPos.Lib.ClassLib
{
    public class DbContent : BaseLib
    {
        public string getUserList(object arg)
        {
            var result=  new List<object>(){
            };
            for (int i = 0; i < 900; i++)
            {
                result.Add(new { a = DateTime.Now});
            }
            return SuccessToJson(result);
        }
    }
}
