using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
namespace IMDB.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [StringLength(50, ErrorMessage = "maximum length for last name is 50")]
        [Required(ErrorMessage = "please enter Password")]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [StringLength(50, ErrorMessage = "maximum length for last name is 50")]
        [Required(ErrorMessage = "please enter first name")]
        [Display(Name = "First Name")]
        public String FName { get; set; }

        [StringLength(50, ErrorMessage = "maximum length for last name is 50")]
        [Required(ErrorMessage = "please enter last name")]
        [Display(Name = "Last Name")]
        public String LName { get; set; }

        [Display(Name = "Role ID")]
        public int Role_ID { get; set; }

        [Display(Name = "UserImage")]
        public byte[] User_Img { get; set; }
    }
}