using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WindowsFormsApp
{
    public static class Converter
    {
        public static string ConvertToJson<T>(T value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }

        public static T ConvertFromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

    }
}
