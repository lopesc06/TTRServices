using System;
using System.ComponentModel.DataAnnotations;

namespace MAJServices.Models
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage ="This field should not be empty")]
        [MaxLength(30)]
        [ConcurrencyCheck]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [MaxLength(40)]
        [ConcurrencyCheck]
        public string LastName { get; set; }

        [StringLength(35)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        public string Role { get; set; }
    }
}
