using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{

    public class DbAdd : IMdbDBContext
    { 
        public int MovieID { get; set; }
        public int UserID { get; set; }

        public void CommentDb(string CommentString)
        {
            Comment Comment = new Comment
            {
                Movie_ID = MovieID,
                User_ID = UserID,
                CommentData = CommentString
            };
            context.Comments.Add(Comment);
            context.SaveChanges();
        }

        public void ActorDb(Actor actor)
        {
            context.Actors.Add(actor);
            context.SaveChanges();
        }

       public void DirectorDb(Director director)
        {
            context.Directors.Add(director);
            context.SaveChanges();
        }

        public void MovieDb(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public void MovieActor(MovieActor movieActor)
        {
            context.MovieActors.Add(movieActor);
            context.SaveChanges();
        }
    }
}