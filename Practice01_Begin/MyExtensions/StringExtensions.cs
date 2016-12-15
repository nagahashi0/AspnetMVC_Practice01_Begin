using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice01_Begin.MyExtensions
{
    public  static class StringExtensions
    {
        public static bool MyExtensionMethod(this string source)
        {
            bool ret = ! String.IsNullOrEmpty(source);
            return ret;
        }


    }
}