using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
