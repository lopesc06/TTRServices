using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Models.User
{
    public class UserSubscriptionDto
    {
        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
