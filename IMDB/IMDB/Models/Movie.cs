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

        [ForeignKey("Director_ID")]
        public int Director_ID { get; set; }

        public byte[] Img1 { get; set; }

        public byte[] Img2 { get; set; }

        public byte[] Img3 { get; set; }

        public String Movie_TLink { get; set; }

    }
}