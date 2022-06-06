using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Book> books { get; set; }
    }
}
