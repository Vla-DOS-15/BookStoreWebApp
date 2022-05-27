using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FIO { get; set; }
        public DateTime DateTime { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int BookId { get; set; }
       // [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
