using BookStoreWebApp.Interfaces;
using BookStoreWebApp.Models;
using System.Collections.Generic;

namespace BookStoreWebApp.Repository
{
    public class CategoryRepository : IBookCategory
    {
        private readonly BookContext bookContext;
        public CategoryRepository(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }
        public IEnumerable<Category> AllCategories => bookContext.Categorys;
    }
}
