using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuongThuc
{
    internal class MyMeThod
    {
        public void XinChao1()
        {
            Console.WriteLine("Xin chào 1!!!");
        }
        public int TinhTong1(int a, int b)
        {
            return a + b;
        }

        public static void XinChao2()
        {
            Console.WriteLine("Xin chào 2!!!");
        }
        public static int TinhTong2(int a, int b)
        {
            return a + b;
        }

        public static int Tich(int a, int b)
        {
            return a * b;
        }

        public static float Tich(float a, float b)
        {
            return a * b;
        }

        public static double Tich(double a, double b)
        {
            return a * b;
        }

        public static string ConvertFullName(string ten, string ho = "Dang", string tenDem = "Van")
        {
            return $"{ho} {tenDem} {ten}";
        }

        public static void BinhPhuong(ref int a)
        {
            a = a * a;
            Console.WriteLine(a);
        }

        public static void BinhPhuong(int a, out int kq)
        {
            kq = a * a;
            Console.WriteLine(kq);
        }
    }
}
