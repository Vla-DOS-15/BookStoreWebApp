using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.Interfaces
{
    public interface IAllBooks
    {
        IEnumerable<Book> Books { get; }
        Book GetObjectBook(int bookId);
    }
}
