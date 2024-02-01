using System;
using Microsoft.EntityFrameworkCore;

namespace ef {
    public class ProductDbContext : DbContext {
        private const string connectString = @"
            Data Source=localhost,1433;
            Initial Catalog=data01;
            User ID=sa;
            PWD=Password123";

        public DbSet<Product> product {set; get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectString); // Cho biết DbContext làm việc với CSDL Sql Server
        }
    }
}