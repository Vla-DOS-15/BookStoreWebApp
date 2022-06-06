using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [Display(Name = "Введіть ПІБ")]
        [StringLength(50)]
        [Required(ErrorMessage = "Повинно бути не бути більше 50 символа")]
        public string FIO { get; set; }

        [Display(Name = "Адреса")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
