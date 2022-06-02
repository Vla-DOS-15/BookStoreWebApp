using Microsoft.AspNetCore.Mvc;
using BookStoreWebApp.Repository;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly BookRepository bookRepository;
        private readonly ShopCart shopCart;
        public ShopCartController(BookRepository bookRepository, ShopCart shopCart)
        {
            this.bookRepository = bookRepository;
            this.shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = shopCart.GetShopCartItems();
            shopCart.ListShopCartItems = items;

            return View();
        }
    }
}
