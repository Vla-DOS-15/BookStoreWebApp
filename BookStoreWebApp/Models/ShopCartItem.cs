namespace BookStoreWebApp.Models
{
    public class ShopCartItem
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdItem { get; set; }
        public Book Book { get; set; }
        public string ShopCartId { get; set; }
    }
}
