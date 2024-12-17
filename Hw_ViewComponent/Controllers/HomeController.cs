using Hw_ViewComponent.Data;
using Hw_ViewComponent.Models;
using Hw_ViewComponent.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hw_ViewComponent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.Include(e => e.Comments).ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var books = await _context.Books.Include(e => e.Comments).FirstOrDefaultAsync(g => g.Id == id);

            if (books == null)
            {
                return NotFound();
            }

            return View(new DetailsViewModel
            { Book = books,
                Comments = books.Comments
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(DetailsViewModel model)
        {
            if(ModelState.IsValid)
            {
                var comment = new Comment
                {   BookId = model.BookId,
                    Content = model.Comment
                };

                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = model.BookId });
            }

            var book = await _context.Books.Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.Id == model.BookId);
            DetailsViewModel detailsViewModel = new DetailsViewModel
            {
                Book = book,
                Comments = book.Comments,
                Comment = model.Comment
            };
            return View(nameof(Details), detailsViewModel);
        }
    }
}
