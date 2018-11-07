using System.ComponentModel.DataAnnotations;

namespace MAJServices.Models
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage ="This field should not be empty")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field should not be empty")]
        [StringLength(40)]
        public string LastName { get; set; }

        [StringLength(35)]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public string DepartmentAcronym { get; set; }
    }
}
