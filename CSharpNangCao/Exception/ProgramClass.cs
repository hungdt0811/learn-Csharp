using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLession
{
    internal class MProgram
    {
        public static void Register(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NameEmtyException();
            }
            Console.WriteLine($"Xin chao {name} ({age})");
        }
    }
}
