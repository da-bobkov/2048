using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string choosenMapSize { get; set; }
        public string Result { get; set; }

        public User(string name, string choosenmapsize)
        {
            Name = name;
            choosenMapSize = choosenmapsize;
        }
    }
}
