using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimeMVCExam.Models
{
    public class Anime
    {
        public int AnimeId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public int ProduktionYear { get; set; }

        [Required]
        public int Episodes { get; set; }

        [Required]
        public string WallPaper { get; set; }

        [Required]
        public string Description { get; set; }

        
    }
}