using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Portfolio.Application.Dtos.Blog
{
    public class GetBlogDto
    {
        public string Id { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public string? Author { get; set; }

        public string? Category { get; set; }

        public DateTime? createdOn { get; set; }

        public DateTime? updatedOn { get; set; }
    }
}
