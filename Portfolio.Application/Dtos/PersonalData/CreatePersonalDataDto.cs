using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Dtos.PersonalData
{
    public class CreatePersonalDataDto
    {
        [Required]
        [DataType(DataType.Url)]
        public string GitHubUrl { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string WhatsappUrl { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string LinkedInUrl { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string FacebookUrl { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string TwitterUrl { get; set; }
    }
}
