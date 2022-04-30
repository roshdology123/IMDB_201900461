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

        public virtual Movie Movie { get; set; }

        [ForeignKey("Movie")]
        [Display(Name = "Movie ID")]
        public int? Movie_ID { get; set; }

        public virtual Actor Actor { get; set; }

        [ForeignKey("Actor")]
        [Display(Name = "Actor ID")]
        public int? Actor_ID { get; set; }

        
    }
}