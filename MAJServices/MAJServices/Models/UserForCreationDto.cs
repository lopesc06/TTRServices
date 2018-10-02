using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Models
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "This field should not be empty")]
        [ConcurrencyCheck]
        public string Id { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [ConcurrencyCheck]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [ConcurrencyCheck]
        public string LastName { get; set; }

        [StringLength(35)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
