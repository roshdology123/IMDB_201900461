using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Movie
    {
        [Key]
        public int Movie_ID { get; set; }

        public String Movie_Name { get; set; }

        public Director Director_ID { get; set; }

        public byte[] Img { get; set; }

        public String Movie_TLink { get; set; }

    }
}