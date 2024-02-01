using System;
using ef;
using Microsoft.EntityFrameworkCore;

namespace EF_01
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDataBase();
            // DropDataBase();
        }

        static void CreateDataBase() {
            using var dbContext = new ProductDbContext();
            string dbname = dbContext.Database.GetDbConnection().Database; // Get Database name
            var kq = dbContext.Database.EnsureCreated();
            if(kq) {
                Console.WriteLine($"{dbname} tao thanh cong");
            }
            else {
                Console.WriteLine($"{dbname} tao that bai");
            }
        }
        static void DropDataBase() {
            using var dbContext = new ProductDbContext();
            string dbname = dbContext.Database.GetDbConnection().Database; // Get Database name
            var kq = dbContext.Database.EnsureDeleted();
            if(kq) {
                Console.WriteLine($"{dbname} xoa thanh cong");
            }
            else {
                Console.WriteLine($"{dbname} xoa that bai");
            }
        }
    }
}
