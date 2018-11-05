using System;
using System.Collections.Generic;
using System.Linq;

namespace MAJServices.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string DepartmentAcronym { get; set; }
        public string UserImageUrl { get; set; }
        public ICollection<PostWithoutUserDto> UserPosts { get; set; } = new List<PostWithoutUserDto>();
        public int NumberOfPosts(){
            return UserPosts.Count();
        }
    }
}
