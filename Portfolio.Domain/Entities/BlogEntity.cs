using Portfolio.Domain.Commons;

namespace Portfolio.Domain.Entities
{
    public class BlogEntity :  BaseModel
    {
        public string Title { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
