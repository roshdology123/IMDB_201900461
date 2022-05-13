﻿using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{

    public class DbData
    {
        IMdbDBContext _context = new IMdbDBContext();
        private User User { get; set;  }

        private IEnumerable<Actor> Actors { get; set; }
        private Actor Actor { get; set; }

        private IEnumerable<Movie> Movies { get; set; }
        private Movie Movie { get; set; }

        private IEnumerable<MovieActor> movieActors { get; set; }

        private IEnumerable<Director> Directors { get; set; }
        private Director Director { get; set; }

        private IEnumerable<Comment> Comments { get; set; }
        private Comment Comment { get; set; }

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

        public Actor RetriveActors(int actorId)
        {
            Actor = _context.Actors.SingleOrDefault(x=>x.Actor_ID == actorId);
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

        public IEnumerable<MovieActor> RetriveMovieActors(int MovieId)
        {
            movieActors =_context.MovieActors.ToList().Where(x => MovieId == x.Movie_ID);
            return movieActors;
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
    }
}