using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAJServices.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public ICollection<FilePath> FilePaths { get; set; } = new List<FilePath>();

        [Required]
        [ForeignKey("DepartmentAcronym")]
        [Column("DepartmentId")]
        public string Department { get; set; }

        [ForeignKey("UserId")]
        public UserIdentity Publisher { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
