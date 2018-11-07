using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Models.FirebaseCM
{
    public class FirebaseCMForCreationDto
    {
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string DeviceId { get; set; }

        [Required]
        [StringLength(250)]
        public string Token { get; set; }
        
    }
}
