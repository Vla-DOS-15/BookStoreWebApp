using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookstoreWebApp.Models
{
    public static class SampleData
    {
        public static void Initialize(BookContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Name = "Колобок",
                        Author = "Народна творчість",
                        YearCreated = 1930,
                        Price = 100
                    },
                    new Book
                    {
                        Name = "Ромео і Джульєта",
                        Author = "Вільям Шекспір",
                        YearCreated = 1527,
                        Price = 400
                    },
                    new Book
                    {
                        Name = "Червона таблетка",
                        Author = "Курпатов Андрій",
                        YearCreated = 2019,
                        Price = 350
                    }
                );
                context.SaveChanges();
            }
        }
    }
}