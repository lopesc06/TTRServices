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
        [DataType(DataType.Date, ErrorMessage = "Incorrect Date, date format is type of MM/DD/YYYY")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date,ErrorMessage = "Incorrect Date, date format is type of MM/DD/YYYY")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Incorrect Date, date format is type of MM/DD/YYYY")]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
