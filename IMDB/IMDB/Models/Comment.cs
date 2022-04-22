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

        [ForeignKey("User_ID")]
        public int User_ID { get; set; }

        [ForeignKey("Movie_ID")]
        public int Movie_ID { get; set; }

        public String CommentData { get; set; }
    }
}