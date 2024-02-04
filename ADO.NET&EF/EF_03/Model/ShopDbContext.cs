using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ef {

    public class ShopDbContext : DbContext {
        // Tạo ILoggerFactory để theo dõi CSDL
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
        builder
               .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
               .AddConsole();
            }
        ); 
        // Cau hinh chuoi ket noi
        private const string connectString = @"
            Data Source = localhost,1433;
            Initial Catalog =shopdata1;
            UID = sa;
            PWD = Password123
        ";

        public DbSet<Product> product {get; set;}   // Khai báo table product
        public DbSet<Category> category {get; set;}   // Khai báo table category
        public DbSet<CategoryDetail> categoryDetail {get; set;}   // Khai báo table categoryDetail
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(loggerFactory)    // - Thiết lập sử Logger
                .UseSqlServer(connectString);       // khai báo làm việc với SQL Server
            // optionsBuilder.UseLazyLoadingProxies(); // Khai báo sử dụng lazyload để tự động nạp các reference 
            Console.WriteLine("OnConfiguring được thực thi");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("OnModelCreating được thực thi");

            // Gọi các Fluent API

            // var entity = modelBuilder.Entity(typeof(Product));
            // entity.

            // var entity = modelBuilder.Entity<Product>();
            // entity.

            modelBuilder.Entity<Product>(entity => {
                // Gọi các Fluent API

                entity.ToTable("Sanpham");          // Table Mapping
                entity.HasKey(p => p.ProductID);    // Primary Key
                entity.HasIndex(p => p.Price)       // Index
                        .HasDatabaseName("price-index");      
                
                // Relationship
                entity.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey("CatID")                     // Đặt tên FK
                    .OnDelete(DeleteBehavior.Cascade)           // Thiết lập action khi xóa table
                    .HasConstraintName("FK_Sanpham_Category");  // Thiết lập tên Constraint

                entity.HasOne(p => p.Category2)
                    .WithMany(c => c.Products)                  // Collect Navigation
                    .HasForeignKey("CatID2")
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sanpham_Category2");
                    
                // Property
                entity.Property(p => p.Name)
                    .HasColumnName("Tên sản phẩm")          // Thiết lập tên cột tương ứng
                    .HasColumnType("nvarchar")              // Thiết lập kiểu dữ liệu cột tương ứng
                    .HasMaxLength(60)                       // Thiết lập độ dài tối đa
                    .IsRequired(true)                       // Thiết lập not null
                    .HasDefaultValue("Sản phẩm mặc định");  // Thiết lập giá trị mặc định
            });
        
            // Mối liên hệ 1 - 1
            modelBuilder.Entity<CategoryDetail>(entity => {
                entity.HasOne(cd => cd.category)        // Một CategoryDetail tương ứng với 1 nào
                    .WithOne(c => c.categoryDetail)     // Một Category tương ứng với 1 nào
                    .HasForeignKey<CategoryDetail>(c => c.CategoryDetailID) // Thiết lập FK trên CategoryDetail là cột CategoryID
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

