using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IMDB.Functions
{

    public class DbData
    {
        private IMdbDBContext _context = new IMdbDBContext();
        
        private User User { get; set;  }
        
        private IEnumerable<Actor> Actors { get; set; }
        private Actor Actor { get; set; }

        private IEnumerable<Movie> Movies { get; set; }
        private Movie Movie { get; set; }

        private IEnumerable<MovieActor> MovieActors { get; set; }
        private IEnumerable<MovieActor> ActorMovies { get; set; }

        private IEnumerable<Director> Directors { get; set; }
        private Director Director { get; set; }

        private IEnumerable<Comment> Comments { get; set; }

        private IEnumerable<Like> Likes { get; set; }
        private Like Like { get; set; }

        public User RetrieveUser(int userId)
        {
            User = _context.Users.Find(userId);
            return User;
        }

        public IEnumerable<Actor> RetriveActors()
        {
            Actors = _context.Actors;
            return Actors;
        }

        public Actor RetriveActors(int? actorId)
        {
            Actor = _context.Actors.SingleOrDefault(x=>x.Actor_ID == actorId);
            return Actor;
            
        }

        public Actor RetriveActors(int actorId)
        {
            Actor = _context.Actors.SingleOrDefault(x => x.Actor_ID == actorId);
            return Actor;
        }

        public IEnumerable<Movie> RetriveMovies()
        {
            Movies = _context.Movies;
            return Movies;
        }

        public Movie RetriveMovies(int movieId)
        {
            Movie = _context.Movies.SingleOrDefault(x=>x.Movie_ID == movieId);
            return Movie;
        }

        public Movie RetriveMovies(int? movieId)
        {
            Movie = _context.Movies.SingleOrDefault(x => x.Movie_ID == movieId);
            return Movie;
        }

        public IEnumerable<Movie> SearchMovies(int? movieId)
        {
            Movies = _context.Movies.Where(x => x.Movie_ID == movieId);
            return Movies;
        }

        public IEnumerable<Movie> RetrieveDirectorMovies(int? directorId)
        {
            Movies = _context.Movies.ToList().Where(x=> x.Director_ID == directorId);
            return Movies;
        }
        public int RetrieveDirectorMoviesCount(int? directorId)
        {
            int count = _context.Movies.ToList().Where(x => x.Director_ID == directorId).Count();
            return count;
        }
        public IEnumerable<MovieActor> RetriveMovieActors(int MovieId)
        {
            MovieActors = _context.MovieActors.Where(x => MovieId == x.Movie_ID).ToList();
            return MovieActors;
        }

        public IEnumerable<MovieActor> RetrieveActorMovies(int ActorId)
        {
            ActorMovies = _context.MovieActors.ToList().Where(x => ActorId == x.Actor_ID);
            return ActorMovies;
        }
        public IEnumerable<Director> RetriveDirectors()
        {
            Directors = _context.Directors;
            return Directors;
        }
        public Director RetriveDirectors(int? directorId)
        {
            Director = _context.Directors.Find(directorId);
            return Director;
        }

        public IEnumerable<Comment> RetrieveFilmComments(int MovieId)
        {
            Comments = _context.Comments.Where(x => MovieId == x.Movie_ID);
            return Comments;
        }

        public Like RetrieveUserMovieLike(int UserId, int MovieId )
        {
            Like = _context.Likes.SingleOrDefault(x => MovieId == x.Movie_ID && x.User_ID == UserId);
            return Like;
        }
        public IEnumerable<Like> RetrieveMovieLikes(int movieId)
        {
            return _context.Likes.Where(x => x.Movie_ID == movieId);
        }

        public int ActorExistMovie(int actorId, int movieId)
        {
            return _context.MovieActors.Where(id => id.Actor_ID == actorId && id.Movie_ID == movieId).Count();
        }
    }
}