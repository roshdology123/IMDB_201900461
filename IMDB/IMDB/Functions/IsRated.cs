using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{
   

    public class IsRated
    {
        IMdbDBContext _context = new IMdbDBContext();

        public int MovieID { get; set; }
        public int UserID { get; set; }

        public bool Validate()
        {
            
            var isValid = false;
            if (_context.Likes.Where(x => MovieID == x.Movie_ID && x.User_ID == UserID).Count() > 0)
            {
                isValid = true;
            }
           
            return isValid;
        }

        public void Insert(LikeExp likeExp)
        {
            Like like = new Like();
            like.Movie_ID = MovieID;
            like.User_ID = UserID;
            like.LikeValue = likeExp;
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        public void Update(LikeExp likeExp)
        {
            Like like = _context.Likes.SingleOrDefault(x => MovieID == x.Movie_ID && x.User_ID == UserID);
            like.Movie_ID = MovieID;
            like.User_ID = UserID;
            like.LikeValue = likeExp;
            _context.SaveChanges();
            
        }
    }
}