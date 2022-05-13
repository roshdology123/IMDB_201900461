using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IMDB.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FName{ get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public String LName { get; set; }

        public int Role_ID { get; set; }
        public byte[] User_Img { get; set; }
    }
    
}