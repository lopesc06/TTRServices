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
        [DataType(DataType.Date)]
        public DataType ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DataType StartDate { get; set; }

        [DataType(DataType.Date)]
        public DataType EndDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<string> FileUrl { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
