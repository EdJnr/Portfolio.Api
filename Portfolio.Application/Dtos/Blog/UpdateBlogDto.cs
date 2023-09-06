using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos.Blog
{
    public class UpdateBlogDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }
    }
}
