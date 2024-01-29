using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNameSpace
{
    internal class Class1
    {
        public static void XinChao()
        {
            Console.WriteLine("Xin chao");
        }
    }

    namespace Abc
    {
        internal class Class1
        {
            public static void XinChao()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Xin chao");
                Console.ResetColor();
            }
        }
    }
}
