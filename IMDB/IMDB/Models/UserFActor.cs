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

        public  User User_ID { get; set; }


        public Actor Actor_ID { get; set; }
    }
}