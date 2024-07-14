using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class FileProvider
    {
        public static bool IsFileExists(string pathToResults)
        {
            return File.Exists(pathToResults); 
        }

        public static string GetValue(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                string result = sr.ReadToEnd();
                return result;
            }
        }

        public static void SetValue(string path, string value)
        {
            using (StreamWriter sr = new StreamWriter(path, false, Encoding.UTF8))
            {
                sr.Write(value);
            }

        }
    }
}
