using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    internal class Class1
    {
        static void Swap(ref int a, ref int b)
        {
            int x = a;
            a = b;
            b = x;
        }

        static void Swap(ref float a, ref float b)
        {
            float x = a;
            a = b;
            b = x;
        }

        static void Swap(ref string a, ref string b)
        {
            string x = a;
            a = b;
            b = x;
        }

        // su dung generic
        internal static void Swap<T>(ref T a, ref T b)
        {
            T x = a;
            a = b;
            b = x;
        }

    }

    internal class Product<A>
    {
        A ID;

        public void setID(A _id)
        {
            ID = _id;
        }

        public void PrintID()
        {
            Console.WriteLine("ID = " + ID);
        }
    }
}
