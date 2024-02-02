using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef {

    public class ShopDbContext : DbContext {
        // Tạo ILoggerFactory 
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
        builder
               .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
               .AddConsole();
            }
        ); 
        // Cau hhinh chuoi ket noi
        private const string connectString = @"
            Data Source= HUNGDT;
            Initial Catalog=shopdata;
            UID = sa;
            PWD = 123
        ";

        public DbSet<Product> product {get; set;}   // Khai báo table product
        public DbSet<Category> category {get; set;}   // Khai báo table category
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(loggerFactory)  // - Thiết lập sử Logger
                .UseSqlServer(connectString); // khai báo làm việc với SQL Server
        }
    }
}

