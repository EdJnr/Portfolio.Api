using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Portfolio.Application.Dtos.PersonalData
{
    public class GetPersonalDataDto
    {
        public string Id { get; set; }

        public string? GitHubUrl { get; set; }

        public string? WhatsappUrl { get; set; }

        public string? LinkedInUrl { get; set; }

        public string? FacebookUrl { get; set; }

        public string? TwitterUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
