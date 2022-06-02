using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookStoreWebApp.Models
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
                        Genre = "Казки",
                        Price = 100,
                        Img = "/img/book1.jpg"
                    },
                    new Book
                    {
                        Name = "Ромео і Джульєта",
                        Author = "Вільям Шекспір",
                        YearCreated = 1527,
                        Genre = "Роман",
                        Price = 400,
                        Img = "https://i.pinimg.com/originals/2b/bf/a8/2bbfa840eeb896f5cec58f581987411d.png"
                    },
                    new Book
                    {
                        Name = "Червона таблетка",
                        Author = "Курпатов Андрій",
                        YearCreated = 2019,
                        Genre = "Психологія",
                        Price = 350,
                        Img = "https://bookchef.ua/upload/iblock/6ec/6ec10cf635c59e14191056e7d94e6988.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}