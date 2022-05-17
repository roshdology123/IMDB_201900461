using IMDB.DataLayer;
using IMDB.Models;
using IMDB.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{
    public class AdminFunctions
    {
        static readonly int nullDirector = 4;
        DbData dbData = new DbData();
        DbDelete dbDelete = new DbDelete();
        private IMdbDBContext context = new IMdbDBContext();
        /// <summary>
        /// Assign Actor Method
        /// </summary>
        /// <param name="actorModel"></param>
        /// <param name="searchedActor"></param>
        public void AssignActor(Actor actorModel, Actor searchedActor)
        {
            searchedActor.FName = actorModel.FName;
            searchedActor.LName = actorModel.LName;
            searchedActor.Age = actorModel.Age;
        }

        /// <summary>
        /// Deletes Actor Movies
        /// </summary>
        /// <param name="id"></param>
        public void DeleteActorMovies(int id)
        {
            foreach (var item in dbData.RetrieveActorMovies(id))
            {
                dbDelete.ActorMoviesDb(item);
            }
        }

        /// <summary>
        /// Updates Director to Null row
        /// </summary>
        /// <param name="movie"></param>
        public void UpdateDirectorToNull(IEnumerable<Movie> movie)
        {
            foreach (var sMovies in movie)
            {
                sMovies.Director_ID = nullDirector;
            }
        }


        /// <summary>
        /// Assigns Director
        /// </summary>
        /// <param name="movieDirectorViewModel"></param>
        /// <param name="directors"></param>
        public void AssignDirector(Movie_Director movieDirectorViewModel, List<Director> directors)
        {
            movieDirectorViewModel.directors = directors;
        }


        /// <summary>
        /// Assigns Movie and Actor into MovieActor View Model
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
       public MovieActorViewModel AssignIntoMovieActorVM(IEnumerable<Actor> actor, IEnumerable<Movie> movie)
        {
            return new MovieActorViewModel()
            {
                Actors = actor,
                Movies = movie
            };
        }


        /// <summary>
        /// Returns Count of Actor in Movies
        /// </summary>
        /// <param name="movieAndActor"></param>
        /// <returns></returns>

        public int CountMovieActors(MovieActorViewModel movieAndActor)
        {
            return context.MovieActors.Where(id => id.Actor_ID == movieAndActor.MovieActor.Actor_ID && id.Movie_ID == movieAndActor.MovieActor.Movie_ID).Count();
        }


        /// <summary>
        /// Assigns Movie and Director into MovieDirector VM
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="directors"></param>
        /// <returns></returns>
        public Movie_Director AssignIntoMovieDirectorVM(Movie movie, List<Director> directors)
        {
            return new Movie_Director
            {
                directors = directors,
                movie = movie
            };
        }


        /// <summary>
        /// Assigns Movie To Another Movie Variable
        /// </summary>
        /// <param name="movieVar"></param>
        /// <param name="movie"></param>
        public void AssignIntoNewMovie(Movie_Director movieVar, Movie movie)
        {
            movie.Movie_Name = movieVar.movie.Movie_Name;
            movie.Movie_TLink = movieVar.movie.Movie_TLink;


            movie.Director_ID = movieVar.movie.Director_ID;
        }
        /// <summary>
        /// Converts Image To Byte Array
        /// </summary>
        /// <param name="MovieImage"></param>
        /// <param name="movie"></param>
        /// <param name="ms"></param>
        public void ImageToByteArray(HttpPostedFileBase MovieImage, Movie movie, MemoryStream ms)
        {
            MovieImage.InputStream.CopyTo(ms);
            byte[] profileArray = ms.ToArray();
            movie.Img = profileArray;
        }


        /// <summary>
        /// Deletes Film Likes
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFilmLikes(int id)
        {
            foreach (var item in dbData.RetrieveMovieLikes(id))
            {
                dbDelete.FilmLikes(item);
            }
        }
        /// <summary>
        /// Deletes Film Comments
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFilmComment(int id)
        {
            foreach (var item in dbData.RetrieveFilmComments(id))
            {
                dbDelete.FilmComments(item);
            }
        }
        /// <summary>
        /// Deletes Movie Actors
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMovieActor(int id)
        {
            foreach (var item in dbData.RetriveMovieActors(id))
            {
                dbDelete.ActorMoviesDb(item);
            }
        }
    }
}