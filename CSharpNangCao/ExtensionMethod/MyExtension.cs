using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLib
{
    public static class Xyz
    {
        public static double BinhPhuong(this double x) => x * x;
        public static double CanBachai(this double x) => Math.Sqrt(x);
        public static double Sin(this double x) => Math.Sin(x);
        public static double Cos(this double x) => Math.Cos(x);
    }
}
