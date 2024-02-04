using System;
using System.Text;
using ef;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EF_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Thực hành với EF");
            Console.WriteLine("----------------");

            DropDB();
            CreateDB();
            // InsertData();
            // GetData();
            // UseLinqtoGetData();

            // using var dbcontext = new ShopDbContext();
            // var category = (from c in dbcontext.category where c.CategoryID == 1 select c).FirstOrDefault();
            // dbcontext.Remove(category);
            // dbcontext.SaveChanges();

        }

        static void CreateDB()
        {
            using var dbcontext = new ShopDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database; // lấy ra tên của DB

            var result = dbcontext.Database.EnsureCreated(); // Tạo DB
            if (result)
            {
                Console.WriteLine($"Database {dbname} đã được tạo");
            }
            else
            {
                Console.WriteLine($"Thất bại trong việc tạo database {dbname}");
            }
        }

        static void DropDB()
        {
            using var dbcontext = new ShopDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database; // lấy ra tên của DB

            var result = dbcontext.Database.EnsureDeleted(); // Xóa DB
            if (result)
            {
                Console.WriteLine($"Database {dbname} đã được xóa thành công");
            }
            else
            {
                Console.WriteLine($"Thất bại trong việc xóa database {dbname}");
            }
        }

        static void InsertData()
        {
            using var dbcontext = new ShopDbContext();

            Category c1 = new Category() { Name = "Điện thoại", Description = "Các loại điện thoại" };
            Category c2 = new Category() { Name = "Đồ uống", Description = "Các loại đồ uống" };
            Category c3 = new Category() { Name = "Xe máy", Description = "Các loại xe máy" };
            dbcontext.category.Add(c1);
            dbcontext.category.Add(c2);
            dbcontext.category.Add(c3);


            // dbcontext.Add(new Category() {Name = "Điện thoại", Description = "Các loại điện thoại"});
            // dbcontext.Add(new Category() {Name = "Đồ uống", Description = "Các loại đồ uống"});
            // dbcontext.Add(new Category() {Name = "Xe máy", Description = "Các loại xe máy"});

            // var cat1 = (from cat in dbcontext.category where cat.CategoryID == 1 select cat).FirstOrDefault();
            // var cat2 = (from cat in dbcontext.category where cat.CategoryID == 2 select cat).FirstOrDefault();
            // var cat3 = (from cat in dbcontext.category where cat.CategoryID == 3 select cat).FirstOrDefault();

            dbcontext.Add(new Product() { Name = "Samsung Glaxy note 10", Price = 1000, CatID = 1 });
            dbcontext.Add(new Product() { Name = "Iphone 11 Promax", Price = 1200, Category = c1 });
            dbcontext.Add(new Product() { Name = "Nước cam", Price = 100, Category = c2 });
            dbcontext.Add(new Product() { Name = "Nước ép dưa hấu", Price = 200, Category = c2 });
            dbcontext.Add(new Product() { Name = "Cocacola", Price = 150, Category = c2 });
            dbcontext.Add(new Product() { Name = "Air Blade", Price = 2500, Category = c3 });
            dbcontext.Add(new Product() { Name = "Sirius", Price = 1600, Category = c3 });


            dbcontext.SaveChanges();
            Console.WriteLine("Tạo dữ liệu mẫu thành công");
        }

        static void GetData()
        {
            using var dbcontext = new ShopDbContext();

            var category = (from cat in dbcontext.category where cat.CategoryID == 2 select cat).FirstOrDefault();

            // // Khai báo sử dụng Property có tham chiếu
            // var e = dbcontext.Entry(category);   // Phương thức entry đang theo dõi đối tượng category
            // e.Collection(c => c.Products).Load();    // Tải dữ liệu tham chiếu từ property

            if(category.Products != null) {
                category.Products.ForEach(p => p.ShowInfo());
            }
            else Console.WriteLine("Products == null");


            // using var dbcontext = new ShopDbContext();
            // var product = (from prod in dbcontext.product where prod.ProductID == 1 select prod).FirstOrDefault();

            // // Khai báo sử dụng Property có tham chiếu
            // var e = dbcontext.Entry(product);   // Phương thức entry đang theo dõi đối tượng product
            // e.Reference(p => p.Category).Load();    // Tải dữ liệu tham chiếu từ property

            // product.ShowInfo();

            // if(product.Category != null) {
            //     Console.WriteLine($"{product.Category.Name} -- {product.Category.Description}");
            // }
            // else Console.WriteLine("Category = null");
        }
    
        static void UseLinqtoGetData() {
            using var dbcontext = new ShopDbContext();
            
            // Lấy ra tên SP, Giá SP và tên danh mục
            var products =  from p in dbcontext.product
                            join c in dbcontext.category on p.CatID equals c.CategoryID
                            select new {
                                tensp = p.Name,
                                giasp = p.Price,
                                danhmucsp = c.Name
                            };
            products.ToList().ForEach(e => Console.WriteLine(e));

            // Lấy ra product có chữ i trong tên và sắp xếp giảm dần theo giá
            // var products =  from p in dbcontext.product 
            //                 where p.Name.Contains("i") 
            //                 orderby p.Price descending
            //                 select p;
            // products.ToList().ForEach(p => p.ShowInfo());

            // Lấy ra product có giá >= 1000
            // var products = from p in dbcontext.product where p.Price >= 1000 select p;
            // products.ToList().ForEach(p => p.ShowInfo());

            // Lấy ra dòng theo PK
            // var p = dbcontext.product.Find(6);
            // p.ShowInfo();
            
        }
    }
}
