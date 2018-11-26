using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAJServices.Entities
{
    public class Department
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string DepartmentAcronym { get; set; }
        
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Color Format Must Be Hexadecimal #")]
        public string HexColor { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string DepartmentImageUrl { get; set; }

        public ICollection<UserIdentity> Members { get; set; } = new List<UserIdentity>();

    }
}
