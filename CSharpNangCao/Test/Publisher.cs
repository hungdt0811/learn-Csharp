using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    delegate void DanhThuc();
    internal class Chicken
    {
        public event DanhThuc danhthuc;
        public void gay()
        {
            Console.WriteLine("O o o ...");
            danhthuc?.Invoke();
        }
    }

    class Fammer
    {
        public void BatSuKien(Chicken chicken)
        {
            chicken.danhthuc += nguDay;
        }
        public void nguDay() 
        {
            Console.WriteLine("Nguoi nong dan ngu day");
        }

        public void raDong()
        {
            Console.WriteLine("Nguoi nong di ra dong");
        }
    }

    class Dog
    {
        public void BatSuKien(Chicken chicken)
        {
            chicken.danhthuc += sua;
        }

        public void sua()
        {
            Console.WriteLine("Gau gau gau !!!");
        }
    }
}
