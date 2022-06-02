using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebApp.Models
{
    public class Cart
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
