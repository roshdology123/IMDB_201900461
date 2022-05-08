using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IMDB.Models
{
    public class Director
    {
        [Key]
        public int Director_ID { get; set; }

        [StringLength(50, ErrorMessage = "maximum length for first name is 50")]
        [Required(ErrorMessage = "please enter first name")]
        [Display(Name = "First Name")]
        public String FName { get; set; }

        [StringLength(50, ErrorMessage = "maximum length for last name is 50")]
        [Required(ErrorMessage = "please enter last name")]
        [Display(Name = "Last Name")]
        public String LName { get; set; }

        [Range(1, 99)]
        [Display(Name = "Age")]
        public int Age { get; set; }

    }
}