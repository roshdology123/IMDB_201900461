using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class UserFActor
    {
        [Key]
        public int ID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        [Display(Name = "User ID")]
        public int? User_ID { get; set; }

        public virtual Actor Actor { get; set; }

        [ForeignKey("Actor")]
        [Display(Name = "Actor ID")]
        public int? Actor_ID { get; set; }
    }
}