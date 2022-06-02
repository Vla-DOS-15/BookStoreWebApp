using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public static class SampleData
    {
        public static void Initialize(BookContext context)
        {
            if (!context.Books.Any())
            {
                var category = new Category 
                { 
                    CategoryName = "Казки", 
                    Desc = "Книги для дітей" 
                };
                context.Categorys.Add(category);
                context.SaveChanges();

                context.Books.AddRange(
                    new Book
                    {
                        Name = "Колобок",
                        Author = "Народна творчість",
                        YearCreated = 1930,
                        Category = category,
                        Price = 100,
                        Img = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/31b681157c4c1a5551b0db4896e7972f/i/m/img223_141.jpg"
                    },
                    new Book
                    {
                        Name = "Ромео і Джульєта",
                        Author = "Вільям Шекспір",
                        YearCreated = 1527,
                        Category = category,
                        Price = 400,
                        Img = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/398x565/31b681157c4c1a5551b0db4896e7972f/3/_/3_208_22.jpg"
                    },
                    new Book
                    {
                        Name = "Червона таблетка",
                        Author = "Курпатов Андрій",
                        YearCreated = 2019,
                        Category = category,
                        Price = 350,
                        Img = "https://bookchef.ua/upload/iblock/6ec/6ec10cf635c59e14191056e7d94e6988.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}