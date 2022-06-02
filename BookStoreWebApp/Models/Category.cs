using System.Collections.Generic;

namespace BookStoreWebApp.Models
{
    public class Category
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
