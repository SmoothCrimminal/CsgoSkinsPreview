using CsGoSkinsPreview.Remote.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGoSkinsPreview.Remote
{
    public static class Tools
    {
        public static Dictionary<string, string> ObjectToDictionary<T>(T source)
        {
            var dict = new Dictionary<string, string>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                if (value is string)
                {
                    dict.Add(property.Name.ToLower(), (string)value);
                }
            }
            return dict;
        }
    }
}
