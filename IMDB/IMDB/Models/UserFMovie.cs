using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFMovie
    {
        [Key]
        public int ID { get; set; }


        public virtual User User { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User ID")]
        public int? User_ID { get; set; }

        public virtual Movie Movie { get; set; }

        [ForeignKey("Movie")]
        [Display(Name = "Movie ID")]
        public int? Movie_ID { get; set; }
    }
}