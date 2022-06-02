using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
    }
}
