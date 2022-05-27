using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        BookContext dbContext;
        public HomeController(BookContext context)
        {
            dbContext = context;
        }
        //public IActionResult Index()
        //{
        //    return View(db.Books.ToList());
        //}
        //private readonly ILogger<HomeController> _logger;
        //BookContext bookContext = new BookContext();
        //public HomeController(ILogger<HomeController> logger)
        //{
            //_logger = logger;
        //}

        public ActionResult Index()
        {
            IEnumerable<Book> books = dbContext.Books;
            ViewBag.Books = books;

            return View();
        }
        //public JsonResult GetUser()
        //{
        //    Book user = new Book { Name = "Tom", Author = "28" };
        //    return Json(user);
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            dbContext.Orders.Add(order);
            // сохраняем в бд все изменения
            dbContext.SaveChanges();
            return "Дякуюємо, " + order.FIO + ", за купівлю!";
        }
    }
}
