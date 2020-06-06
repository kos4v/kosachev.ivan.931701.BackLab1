using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackLab1.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TopicId { get; set; }
        public Topic Topic { get; set;}
        [Required]
        public string Title { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public int Picture1Id { get; set; }

        [Required]
        public int Picture2Id { get; set; }

        [Required]
        public int Picture3Id { get; set; }

    }
}
