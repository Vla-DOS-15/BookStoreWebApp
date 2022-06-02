using Microsoft.AspNetCore.Mvc;
using BookStoreWebApp.Repository;
using BookStoreWebApp.Models;
using BookStoreWebApp.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Interfaces;

namespace BookStoreWebApp.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllBooks bookRepository;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllBooks bookRepository, ShopCart shopCart)
        {
            this.bookRepository = bookRepository;
            this.shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = shopCart.GetShopCartItems();
            shopCart.ListShopItems = items;
            var obj = new ShopCartViewModel { shopCart = shopCart };

            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = bookRepository.Books.FirstOrDefault(i => i.Id == id);
            if (item == null)
                shopCart.AddToCart(item);
            return RedirectToAction("Index");
        }
    }
}
