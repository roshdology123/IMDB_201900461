using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class Comment
    {
        [Key]
        public int Comment_ID { get; set; }

        [Display(Name = "User ID")]
        public User User_ID { get; set; }

        [Display(Name = "Movie ID")]
        public Movie Movie_ID { get; set; }

        [Display(Name = "Comment Data")]
        public String CommentData { get; set; }
    }
}