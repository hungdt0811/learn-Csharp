using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethod
{
    internal class Product
    {
        protected double price {  get; set; }

        public virtual void productInfo()
        {
            Console.WriteLine("Gia san pham la: " + price);
        }

        public void test()
        {
            productInfo();
        }
    }

    class Iphone : Product
    {
        public Iphone() {
            price = 500;
        }

        public override void productInfo()
        {
            Console.WriteLine("Gia iphone la: " + price);
        }
    }
}
