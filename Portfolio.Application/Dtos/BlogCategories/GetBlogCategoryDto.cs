using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Portfolio.Application.Dtos.BlogCategories
{
    public class GetBlogCategoryDto
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
