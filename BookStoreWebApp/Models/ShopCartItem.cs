using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.Models
{
    public class ShopCartItem
    {
        [Key]
        public int ItemId { get; set; }
        public Book Book { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
