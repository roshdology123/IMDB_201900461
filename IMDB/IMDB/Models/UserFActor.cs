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

        [ForeignKey("User_ID")]
        public int User_ID { get; set; }

        [ForeignKey("Actor_ID")]
        public int Actor_ID { get; set; }
    }
}