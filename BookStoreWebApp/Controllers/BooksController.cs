using BookStoreWebApp.Interfaces;
using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class BooksController : Controller
    {
        private IAllBooks bookRepository;
        private readonly ShopCart shopCart;
        public IActionResult Index()
        {
            return View();
        }
    }
}
