using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Models
{
    public class PostWithoutUserDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public ICollection<FilePathDto> FilePaths { get; set; } = new List<FilePathDto>();
    }
}
