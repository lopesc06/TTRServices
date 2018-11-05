using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Entities
{
    public class UserSubscription
    {
        
        [Column("DepartmentId")]
        [ForeignKey("DepartmentAcronym")]
        public string DepartmentAcronym { get; set; }
        
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public UserIdentity User { get; set; }
        public Department Department { get; set; }
    }
}
