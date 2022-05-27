using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace BookStoreWebApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

    }
}
