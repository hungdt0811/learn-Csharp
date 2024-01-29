using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPham
{
    internal partial class Product
    {
        public string Description { get; set; }

        public Factory factory { get; set; }

        public class Factory
        {
            public string name { get; set; }
            public string address { get; set; }
        }
    }
}
