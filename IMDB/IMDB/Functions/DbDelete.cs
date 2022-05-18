using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IMDB.Functions
{
    
    public class DbDelete
    {
        DbData dbData = new DbData();
        private IMdbDBContext context = new IMdbDBContext();
        public void ActorDb(Actor actor)
        {
            var searchedActor = context.Actors.SingleOrDefault(x => x.Actor_ID == actor.Actor_ID);
            context.Actors.Remove(searchedActor);
            context.SaveChanges();
        }

        public void ActorMoviesDb(MovieActor movieActor)
        {
            var actorMovies = context.MovieActors.FirstOrDefault(x => movieActor.Actor_ID == x.Actor_ID);
            context.MovieActors.Remove(actorMovies);
            context.SaveChanges();
        }
        public void DirectorDb(Director director)
        {
            var searchedDirector = context.Directors.FirstOrDefault(x => x.Director_ID == director.Director_ID);
            context.Directors.Remove(searchedDirector);
            context.SaveChanges();
        }
        public void FilmComments(Comment comment)
        {
            var searchedComment = context.Comments.FirstOrDefault(x => x.Comment_ID == comment.Comment_ID);
            context.Comments.Remove(searchedComment);
            context.SaveChanges();
        }
        public void FilmLikes(Like like)
        {
            var searchedLike = context.Likes.FirstOrDefault(x => x.ID == like.ID);
            context.Likes.Remove(searchedLike);
            context.SaveChanges();
        }
        public void MovieDb(Movie movie)
        {
            var searchedMovie = context.Movies.FirstOrDefault(x => x.Movie_ID == movie.Movie_ID);
            context.Movies.Remove(searchedMovie);
            context.SaveChanges();
        }

        public void UserFMovieDb(UserFMovie deleteFavoMovie)
        {
            UserFMovie searchedFMovie = dbData.RetrieveUserFMovie(deleteFavoMovie.Movie_ID, deleteFavoMovie.User_ID);
            context.UserFMovies.Remove(deleteFavoMovie);
            context.SaveChanges();
        }

        public void UserFActorDb(UserFActor deleteFavoActor)
        {
            var searchedFavoActor = dbData.RetrieveUserFActor(deleteFavoActor.User_ID, deleteFavoActor.Actor.Actor_ID);
            context.UserFActors.Remove(deleteFavoActor);
            context.SaveChanges();
        }

        public void UserFDirectorDb(UserFDirector deleteFavoDirector)
        {
            UserFDirector searchedFDirector = context.UserFDirectors.SingleOrDefault(m => m.Director_ID == deleteFavoDirector.Director_ID && m.User_ID == deleteFavoDirector.User_ID);
            context.UserFDirectors.Remove(deleteFavoDirector);
            context.SaveChanges();
        }
    }
}