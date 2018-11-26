using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Models.FirebaseCM
{
    public class NotificationForCreationDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}
