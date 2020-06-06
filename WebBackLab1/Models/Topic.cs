﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackLab1.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Reply { get; set; }
        [Required]
        public int AccountCreatorName { get; set; }
        public Account AccountCreator { get; set; }
        [Required]
        public int AccountEditorName { get; set; }
        public Account AccountEditor { get; set; }
        public string DateCreate { get; set; }
        public string DateEdit { get; set; }

        public List<Post> Posts { get; set; }
      
        public int ForumID { get; set; }
        public Forum Forum { get; set; }
        public Topic()
        {
            Posts = new List<Post>();
        }
    }
}
