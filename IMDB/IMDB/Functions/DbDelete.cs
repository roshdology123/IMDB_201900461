using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{
    public class DbDelete : IMdbDBContext
    {
        private IMdbDBContext context = new IMdbDBContext();
        public void ActorDb(Actor actor)
        {
            context.Actors.Remove(actor);
            context.SaveChanges();
        }

        public void ActorMoviesDb(MovieActor movieActor)
        {
            context.MovieActors.Remove(movieActor);
            context.SaveChanges();
        }
        public void DirectorDb(Director director)
        {
            context.Directors.Remove(director);
            context.SaveChanges();
        }
        public void FilmComments(Comment comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
        public void FilmLikes(Like like)
        {
            context.Likes.Remove(like);
            context.SaveChanges();
        }
        public void MovieDb(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}