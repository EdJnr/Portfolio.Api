using Portfolio.Domain.Commons;

namespace Portfolio.Domain.Entities
{
    public class PersonalDataEntity : BaseModel
    {
        public string GitHubUrl { get; set; } = string.Empty;

        public string WhatsappUrl { get; set; } = string.Empty;

        public string LinkedInUrl { get; set; } = string.Empty;

        public string FacebookUrl { get; set; } = string.Empty;

        public string TwitterUrl { get; set; } = string.Empty;
    }
}
