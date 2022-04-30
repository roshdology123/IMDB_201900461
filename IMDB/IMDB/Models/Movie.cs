using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Movie
    {
        [Key]
        public int Movie_ID { get; set; }

        [Display(Name = "Movie Name")]
        public String Movie_Name { get; set; }

        public Director Director { get; set; }

        [ForeignKey("Director")]
        [Display(Name = "Director ID")]
        public int? Director_ID { get; set; }

        [Display(Name = "Movie Image")]
        public byte[] Img { get; set; }

        [Display(Name = "Movie Trailer Link")]
        public String Movie_TLink { get; set; }

    }
}