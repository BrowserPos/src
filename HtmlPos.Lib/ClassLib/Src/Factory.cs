using System;
using System.Collections.Generic;
using System.Reflection;
using HtmlPos.Lib.ClassLib.Controller;

namespace HtmlPos.Lib.ClassLib
{
    public static class Factory
    {
        static Factory()
        {
            Init();
        }
        private static List<Type> _iControllerList = new List<Type>();
        private static void Init()
        {
            var assebmly = Assembly.GetExecutingAssembly();
            var types = assebmly.GetTypes();
            var list = new List<Type>();
            foreach (var t in types)
            {
                if (!t.IsClass) continue;
                Type[] objType = t.FindInterfaces((typeObj, criteriaObj) => typeObj.FullName == criteriaObj.ToString(),
                    typeof(IController).FullName);
                if (objType.Length > 0)
                    _iControllerList.Add(t);
            }
        }
        public static IController GetController(string url)
        {
            var urls = url.Split('/');
            if (urls.Length == 2)
            {
                foreach (var ic in _iControllerList)
                {
                    if (ic.Name.Replace("Controller", "").Equals(urls[0],StringComparison.OrdinalIgnoreCase))
                    {
                        var instance = GetInstance(ic);
                        return instance;
                    }
                }
            }
            return null;
        }

        static IController GetInstance(Type t)
        {
            //TODO:添加缓存/单例功能
            return Activator.CreateInstance(t) as IController;
        }
    }
}
