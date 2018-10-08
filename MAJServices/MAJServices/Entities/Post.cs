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
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<FilePath> FilePaths { get; set; }

        [ForeignKey("UserId")]
        public UserIdentity Publisher { get; set; }
        public string UserId { get; set; }

    }
}
