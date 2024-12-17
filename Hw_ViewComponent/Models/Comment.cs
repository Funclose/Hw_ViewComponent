namespace Hw_ViewComponent.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Content { get; set; }
        public DateTime PostedTime { get; set; }
        public Book Books { get; set; }
    }
}
