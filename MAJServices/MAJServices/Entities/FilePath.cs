using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Entities
{
    public class FilePath
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string Path { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}
