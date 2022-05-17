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


        [StringLength(50, ErrorMessage = "maximum length for movie name is 50")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please enter movie name")]
        [Display(Name = "Movie Name")]
        public String Movie_Name { get; set; }

        public Director Director { get; set; }

        [ForeignKey("Director")]
        [Display(Name = "Director ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "please choose director")]
        public int? Director_ID { get; set; }

        [Display(Name = "Movie Image")]
        public byte[] Img { get; set; }

        [Required(AllowEmptyStrings = false ,ErrorMessage = "please enter movie's trailer link")]
        [Display(Name = "Movie Trailer Link")]
        public String Movie_TLink { get; set; }

    }
}