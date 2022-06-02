using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Models
{
    public class ShopCart
    {
        private readonly BookContext bookContext;
        public ShopCart(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }
        [System.ComponentModel.DataAnnotations.Key]
        public string shopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<BookContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context){ shopCartId = shopCartId };
        }

        public void AddToCart(Book book)
        {
            bookContext.ShopCartItems.Add(new ShopCartItem { 
                ShopCartId = shopCartId, 
                Book = book });
            bookContext.SaveChanges();
        }
        public List<ShopCartItem> GetShopCartItems()
        {
            return bookContext.ShopCartItems.Where(w => w.ShopCartId == shopCartId).Include(i => i.Book).ToList();
        }
    }
}
