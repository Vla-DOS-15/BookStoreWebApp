using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.Interfaces
{
    public interface IBookCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
