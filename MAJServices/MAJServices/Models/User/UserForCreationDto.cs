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
        [StringLength(50)]
        public string Id { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [StringLength(80)]
        public string LastName { get; set; }

        [StringLength(35)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [StringLength(30)]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }

        public string DepartmentAcronym { get; set; }
    }
}
