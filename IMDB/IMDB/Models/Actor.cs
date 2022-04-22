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

        public String FName { get; set; }

        public String LName { get; set; }

        public int Age { get; set; }
    }
}