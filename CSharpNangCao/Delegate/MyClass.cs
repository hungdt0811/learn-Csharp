using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class MyClass
    {
        public static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        public static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        public static string ShowCal(string cal, int a, int b)
        {
            switch (cal)
            {
                case "tổng":
                    return $"{cal} của {a} và {b} là {a + b}";
                case "hiệu":
                    return $"{cal} của {a} và {b} là {a - b}";
                case "tích":
                    return $"{cal} của {a} và {b} là {a * b}";
                default: return "";
            }
        }

        //void Tong(int a, int b, ShowLog log)
        //{
        //    int result = a + b;
        //    log?.Invoke($"Ket qua la: {result}");
        //}

    }
    internal delegate void ShowLog(string message);

}
