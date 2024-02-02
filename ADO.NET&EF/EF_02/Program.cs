using System;
using System.Text;
using ef;
using Microsoft.EntityFrameworkCore;

namespace EF_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Thực hành với EF");
            Console.WriteLine("----------------");


            CreateDB();
            // DropDB();

        }

        static void CreateDB() {
            using var dbcontext = new ShopDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database; // lấy ra tên của DB
            
            var result = dbcontext.Database.EnsureCreated(); // Tạo DB
            if(result) {
                Console.WriteLine($"Database {dbname} đã được tạo");
            }
            else {
                Console.WriteLine($"Thất bại trong việc tạo database {dbname}");
            }
        }

        static void DropDB() {
            using var dbcontext = new ShopDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database; // lấy ra tên của DB
            
            var result = dbcontext.Database.EnsureDeleted(); // Xóa DB
            if(result) {
                Console.WriteLine($"Database {dbname} đã được xóa thành công");
            }
            else {
                Console.WriteLine($"Thất bại trong việc xóa database {dbname}");
            }
        }
    }
}
