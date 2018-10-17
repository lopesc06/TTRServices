using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAJServices.Entities
{
    public class UserIdentity : IdentityUser
    {
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        public string UserImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        [ForeignKey("DepartmentAcronym")]
        public Department Department { get; set; }
        public string DepartmentAcronym { get; set; }
    }
}

