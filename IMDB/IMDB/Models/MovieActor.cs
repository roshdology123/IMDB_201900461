using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieActor
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Movie ID")]
        public Movie Movie_ID { get; set; }

        [Display(Name = "Actor ID")]
        public Actor Actor_ID { get; set; }
    }
}