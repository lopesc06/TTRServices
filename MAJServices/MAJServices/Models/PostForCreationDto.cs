using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Models
{
    public class PostForCreationDto
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Incorrect Date, date format is type of 12/22/2018")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date,ErrorMessage = "Incorrect Date, date format is type of 12/22/2018")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Incorrect Date, date format is type of 12/22/2018")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
