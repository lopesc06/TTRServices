using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAJServices.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [StringLength(35)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }
       
        public string UserImageUrl { get; set; }
       
        public ICollection<Post> UserPosts { get; set; } = new List<Post>();

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public string DepartmentId { get; set; }
    }
}
}
