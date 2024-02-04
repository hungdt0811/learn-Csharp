using System;
using System.Text;

namespace MigrationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Migration--");
            Console.OutputEncoding = Encoding.UTF8;

            var dbcontext = new WebContext();
            dbcontext.Database.EnsureCreated(); // Tạo CSDL
        }
    }
}
