using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            Initial Catalog =shopdata;
            UID = sa;
            PWD = Password123
        ";

        public DbSet<Product> product {get; set;}   // Khai báo table product
        public DbSet<Category> category {get; set;}   // Khai báo table category
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(loggerFactory)    // - Thiết lập sử Logger
                .UseSqlServer(connectString);       // khai báo làm việc với SQL Server
            // optionsBuilder.UseLazyLoadingProxies(); // Khai báo sử dụng lazyload để tự động nạp các reference
                

        }
    }
}

