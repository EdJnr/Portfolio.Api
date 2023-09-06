using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos.BlogCategories
{
    public class CreateBlogCategoryDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Remarks { get; set; }
    }
}
