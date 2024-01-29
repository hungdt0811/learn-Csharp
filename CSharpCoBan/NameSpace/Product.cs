using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPham
{
    internal partial class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string GetInfo()
        {
            return $"{Name} / {Price} / {Description}";
        }

        public string getFactory()
        {
            return $"{this.factory.name} // Dia chi: {this.factory.address}";
        }
    }
}
