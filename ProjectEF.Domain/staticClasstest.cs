using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Domain
{
    public static class staticClasstest
    {
        public static string? Test1;
        public static string? Test2;
        public static string? Test3;


        public static string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == null)
                    name = value;
                //else throw new Exception("...");
            }
        }
        private static string name;

    }
}
