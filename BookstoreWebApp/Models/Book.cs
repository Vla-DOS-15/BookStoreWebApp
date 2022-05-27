using System.Collections.Generic;
namespace BookStoreWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearCreated { get; set; }
        public decimal Price { get; set; }
        public string? Img { get; set; }
        //public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
