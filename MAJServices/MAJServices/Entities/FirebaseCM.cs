using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Entities
{
    public class FirebaseCM
    {
        //PK Compound PK defined in modelbuilder
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        //PK Compound PK defined in modelbuilder
        [MaxLength(250)]
        public string DeviceId { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Token { get; set; }

        public UserIdentity User { get; set; }

    }
}
