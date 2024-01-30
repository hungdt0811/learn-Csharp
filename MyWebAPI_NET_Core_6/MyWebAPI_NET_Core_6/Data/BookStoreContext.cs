using Microsoft.EntityFrameworkCore;

namespace MyWebAPI_NET_Core_6.Data
{
    public class BookStoreContext :DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) 
        {

        }

        #region DbSet
        public DbSet<Book>? Books { get; set;}
        #endregion
    }
}
