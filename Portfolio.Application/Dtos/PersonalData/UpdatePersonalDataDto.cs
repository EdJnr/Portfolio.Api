using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Dtos.PersonalData
{
    public class UpdatePersonalDataDto
    {
        [Required]
        public string Id { get; set; }

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

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }
    }
}
