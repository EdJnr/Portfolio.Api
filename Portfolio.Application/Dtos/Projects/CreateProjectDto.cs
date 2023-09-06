using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos.Projects
{
    public class CreateProjectDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string Technologies { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.ImageUrl)]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Url)]
        public string? GithubUrl { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string? LiveUrl { get; set; }
    }
}
