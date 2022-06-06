using BookStoreWebApp.Interfaces;
using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks allBooks;
        private readonly IBookCategory bookCategory;
        public BooksController (IAllBooks allBooks, IBookCategory bookCategory)
        {
            this.allBooks = allBooks;
            this.bookCategory = bookCategory;
        }
        //public ViewResult List(string category)
        //{
        //    string _category = category;
        //    IEnumerable<Book> books;
        //    string currCategory = "";
        //    if (string.IsNullOrEmpty(category))
        //    {
        //        books = allBooks.Books.OrderBy(i=>i.Id);
        //    }
        //    else
        //    {
        //        if(string.Equals("kazki", category, System.StringComparison.OrdinalIgnoreCase))
        //        {
        //            books = allBooks.Books.Where(i => i.Category.CategoryName.Equals("Казки")).OrderBy(i=>i.Id);
        //        }
        //        else if (string.Equals("psihologi", category, System.StringComparison.OrdinalIgnoreCase))
        //            books = allBooks.Books.Where(i => i.Category.CategoryName.Equals("Психологія")).OrderBy(i => i.Id);
        //    }
        //    currCategory = category;
        //    var bookObj  = new Book
        //}
//                        if(category == null)
//                {
//                    var list = new Category[]
//                    {
//                        new Category{CategoryName = "Казки", Desc = "Для дітей"},
//                        new Category{CategoryName = "Психологія", Desc = ""}
//                    };
//        category = new Dictionary<string, Category>();
//                    foreach(Category el in list)
//                    {
//                        category.Add(el)
//    }
//}
        public IActionResult Index()
        {
            return View();
        }
    }
}
