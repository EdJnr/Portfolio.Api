using Portfolio.Domain.Commons;

namespace Portfolio.Domain.Entities
{
    public class ProjectEntity : BaseModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Technologies { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string GithubUrl { get; set; } = string.Empty;

        public string LiveUrl { get; set; } = string.Empty;
    }
}
