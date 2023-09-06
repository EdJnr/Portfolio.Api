using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos.BlogCategories
{
    public class UpdateBlogCategoryDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Remarks { get; set; }

        [Required]
        public DateTime? UpdatedOn { get; set; }
    }
}
