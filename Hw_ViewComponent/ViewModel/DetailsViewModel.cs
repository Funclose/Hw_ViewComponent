using Hw_ViewComponent.Models;

namespace Hw_ViewComponent.ViewModel
{
    public class DetailsViewModel
    {
        public string? Comment { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
