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

        public String Email { get; set; }

        public String Password { get; set; }

        public String FName{ get; set; }

        public String LName { get; set; }

        public int Role_ID { get; set; }

        public byte[] User_Img { get; set; }
    }
}