using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearCreated { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ushort Price { get; set; }
        public string Img { get; set; }
    }
}
