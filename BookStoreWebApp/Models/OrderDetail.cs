namespace BookStoreWebApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public uint Price { get; set; }
        public string Email { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
