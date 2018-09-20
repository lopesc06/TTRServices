using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cityinfo.API.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a value name")]
        [MaxLength(50, ErrorMessage = "Your length must be less than 50")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "You should use less than 200 letters")]
        public string Description { get; set; }
    }
}
