using Portfolio.Domain.Commons;

namespace Portfolio.Domain.Entities
{
    public class BlogCategoryEntity : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;
    }
}
