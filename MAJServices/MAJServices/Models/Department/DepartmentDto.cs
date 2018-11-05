using System;
using System.Collections.Generic;

namespace MAJServices.Models
{
    public class DepartmentDto
    {
        public string Name { get; set; }
        public string HexColor { get; set; }
        public string DepartmentImageUrl { get; set; }
        public ICollection<UserDto> Members { get; set; } = new List<UserDto>();
    }
}
