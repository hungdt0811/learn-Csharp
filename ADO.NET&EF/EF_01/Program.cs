using System;
using System.Linq;
using System.Text;
using ef;
using Microsoft.EntityFrameworkCore;

namespace EF_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // CreateDataBase();
            // DropDataBase();
            // InsertProduct();
            // ReadProduct();
            // RenameProduct(1, "Laptop");
            DeleteProduct(3);
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
        // Chèn data
        static void InsertProduct() {
            using var dbcontext = new ProductDbContext();
            // var p1 = new Product();
            // p1.ProductName = "Điện thoại";
            // p1.Provider = "Nokia";
            // dbcontext.Add(p1);

            var products = new object[] {
                new Product() {ProductName = "Xe máy", Provider = "Yamaha"},
                new Product() {ProductName = "Ô tô", Provider = "Vinfast"},
                new Product() {ProductName = "Nồi cơm điện", Provider = "Sun House"},
            };
            dbcontext.AddRange(products);

            int number_row = dbcontext.SaveChanges();

            Console.WriteLine($"Đã chèn {number_row} dòng data");
        }
        // ĐỌc data
        static void ReadProduct() {
            using var dbcontext = new ProductDbContext();

            // lấy tất cả sp
            var products = dbcontext.product.ToList();
            products.ForEach(product => {
                Console.WriteLine($"{product.ProductName} - {product.Provider}");
            });
            // Linq: Lấy tất cả sp có id >=3
            var query = from product in dbcontext.product
                        where product.ProductID >= 3
                        select product;

            query.ToList().ForEach(product => {
                Console.WriteLine($"{product.ProductName} - {product.Provider}");
            });


        }
    
        // update data
        static void RenameProduct(int id, string newName) {
            using var dbcontext = new ProductDbContext();

            // lay ra sp co productid = id
            var query = from product in dbcontext.product
                        where product.ProductID == id
                        select product;

            if(query.FirstOrDefault() != null) {
                query.FirstOrDefault().ProductName = newName;   
                int number_row = dbcontext.SaveChanges();
                Console.WriteLine($"Đã cập nhật {number_row} dòng data");
            }
        }
    
        static void DeleteProduct(int id) {
            using var dbcontext = new ProductDbContext();

            // lay ra sp co productid = id
            var query = from product in dbcontext.product
                        where product.ProductID == id
                        select product;

            if(query.FirstOrDefault() != null) {
                dbcontext.Remove(query.FirstOrDefault());
                int number_row = dbcontext.SaveChanges();
                Console.WriteLine($"Đã xóa {number_row} dòng data");
            }
        }
    }
}
