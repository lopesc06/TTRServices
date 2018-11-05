namespace MAJServices.Models
{
    public class UserWithoutPostsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserImageUrl { get; set; }
        public string DepartmentAcronym { get; set; }
    }
}
