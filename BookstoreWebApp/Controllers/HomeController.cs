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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
            //var _book = dbContext.Books;
            //ViewBag.book = _book;
            //return View();
            IEnumerable<Book> books = dbContext.Books;
            ViewBag.Books = books;

            return View();
        }

        //public JsonResult GetUser()
        //{
        //    Book user = new Book { Name = "Tom", Author = "28" };
        //    return Json(user);
        //}
        //ADD CART
        public List<Book> getAllProduct()
        {
            return dbContext.Books.ToList();
        }

        //GET DETAIL PRODUCT
        public Book getDetailProduct(int id)
        {
            var book = dbContext.Books.Find(id);
            return book;
        }
        public IActionResult addCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var book = getDetailProduct(id);
                List<Cart> listCart = new List<Cart>()
               {
                   new Cart
                   {
                       Book = book,
                       Quantity = 1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));
            }
            else
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Book.Id == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new Cart
                    {
                        Book = getDetailProduct(id),
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                // var cart2 = HttpContext.Session.GetString("cart");//get key cart
                //  return Json(cart2);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ListCart()
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult updateCart(int id, int quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (quantity > 0)
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Book.Id == id)
                        {
                            dataCart[i].Quantity = quantity;
                        }
                    }


                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
                var cart2 = HttpContext.Session.GetString("cart");
                return Ok(quantity);
            }
            return BadRequest();
        }
        public IActionResult deleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Book.Id == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return RedirectToAction(nameof(ListCart));
            }
            return RedirectToAction(nameof(Index));
        }
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
            if (id == null) 
                return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public ActionResult<string> Buy(Order order)
        {
            if (order.FIO != null || order.Address != null || order.Email != null)
            {
                order.DateTime = DateTime.Now;
                dbContext.Orders.Add(order);
                // сохраняем в бд все изменения
                dbContext.SaveChanges();
                return "Дякуємо, " + order.FIO + ", за купівлю!";
            }
            else
                return Index();

        }
    }
}
