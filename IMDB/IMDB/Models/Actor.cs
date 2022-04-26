using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMDB.Models
{
    public class Actor
    {
        [Key]
        public int Actor_ID { get; set; }

        [Display(Name = "First Name")]
        public String FName { get; set; }

        [Display(Name = "Last Name")]
        public String LName { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}