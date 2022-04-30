using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFDirector
    {
        [Key]
        public int ID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User ID")]
        public int? User_ID { get; set; }

        public Director Director { get; set; }

        [ForeignKey("Director")]
        [Display(Name = "Director ID")]
        public int? Director_ID { get; set; }
    }
}