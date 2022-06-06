using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
