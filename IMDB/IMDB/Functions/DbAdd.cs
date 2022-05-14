using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{

    public class DbAdd
    { 
        public int MovieID { get; set; }
        public int UserID { get; set; }
        IMdbDBContext _context = new IMdbDBContext();

        public void CommentDb(string CommentString)
        {
            Comment Comment = new Comment();
            Comment.Movie_ID = MovieID;
            Comment.User_ID = UserID;
            Comment.CommentData = CommentString;
            _context.Comments.Add(Comment);
            _context.SaveChanges();
        }
    }
}