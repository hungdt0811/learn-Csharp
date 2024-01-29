using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    internal class MyClass
    {
        //public static void Print(string s, ConsoleColor color)
        //{
        //    Console.ForegroundColor = color;
        //    Console.WriteLine(s);
        //} 
    }

    static class Abc
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
}
