using Hw_ViewComponent.Models;
using Microsoft.EntityFrameworkCore;

namespace Hw_ViewComponent.Data
{
    public class Dbinitial
    {
        public static async Task InitializeBookAsync(ApplicationContext context)
        {
            if (!await context.Books.AnyAsync())
            {
                context.Books.AddRange
                       (
                        new Book { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Price = 450.50 },
                        new Book { Title = "Преступление и наказание", Author = "Фёдор Достоевский", Genre = "Роман", Price = 399.99 },
                        new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Фантастика", Price = 520.00 },
                        new Book { Title = "Евгений Онегин", Author = "Александр Пушкин", Genre = "Поэма", Price = 299.99 },
                        new Book { Title = "Анна Каренина", Author = "Лев Толстой", Genre = "Роман", Price = 470.00 },
                        new Book { Title = "Герой нашего времени", Author = "Михаил Лермонтов", Genre = "Роман", Price = 350.75 }
                        );
                await context.SaveChangesAsync();
            }
        }
    }
}
