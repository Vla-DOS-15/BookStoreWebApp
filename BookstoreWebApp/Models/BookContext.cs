using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace BookstoreWebApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Initial Catalog=BookContext;Integrated Security=true;");
        //}
    }
}
