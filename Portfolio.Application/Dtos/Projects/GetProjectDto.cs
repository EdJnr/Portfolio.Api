using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Portfolio.Application.Dtos.Projects
{
    public class GetProjectDto
    {
        public string Id { get; set; }

        public string? Title{ get; set; }

        public string? Description{ get; set; }

        public string? Technologies { get; set; }

        public string? ImageUrl{ get; set; }

        public string? GithubUrl{ get; set; }

        public string? LiveUrl{ get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
