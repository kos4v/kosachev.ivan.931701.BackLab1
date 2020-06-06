using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBackLab1.Models
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Picture> Pictures { get; set; }
        public int FoldersId { get; set; }
        public Folder Folders { get; set; }
        public Folder()
        {
            Pictures = new List<Picture>();
        }
    }
}
