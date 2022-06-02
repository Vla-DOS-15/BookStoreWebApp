using BookStoreWebApp.Interfaces;
using BookStoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWebApp.Repository
{
    public class BookRepository : IAllBooks
    {
        private readonly BookContext bookContext;
        public BookRepository(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }
        public IEnumerable<Book> Books => bookContext.Books.Include(c => c.Category);

        public Book GetObjectBook(int bookId) => bookContext.Books.FirstOrDefault(p => p.Id == bookId);
    }
}
