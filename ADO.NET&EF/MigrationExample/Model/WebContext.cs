using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MigrationExample {
    public class WebContext : DbContext {

        // Chuỗi kết nối
        private const string connectString = @"
            Data Source = localhost,1433;
            Initial Catalog = webdb;
            UID = sa;
            PWD = Password123
        ";

        // Khai báo table
        public DbSet<Article> articleTable {get; set;}
        public DbSet<Tag> tagTable {get; set;}

        // Tạo ILoggerFactory để theo dõi CSDL
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
        builder
               .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
               .AddConsole();
            }
        ); 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}