using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedListExample
{
    internal class Data
    {
        public List<Product> products = new List<Product>()
        {
            new Product()
            {
                name = "Iphone X", price = 1000, origin = "Trung Quoc", id = 1
            },
            new Product()
            {
                name = "Iphone 14", price = 3000, origin = "Trung Quoc", id = 2
            },
            new Product()
            {
                name = "Samsung s23", price = 2000, origin = "Han Quoc", id = 3
            },
            new Product()
            {
                name = "Vsmart", price = 800, origin = "Viet Nam", id = 4
            },
            new Product()
            {
                name = "Sony", price = 900, origin = "Nhat Ban", id = 5
            },
            new Product()
            {
                name = "Nokia", price = 600, origin = "My", id = 7
            },
            new Product()
            {
                name = "Huaway", price = 1200, origin = "Trung Quoc", id = 8
            }
        };
    }
}
