using IMDB.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using IMDB.ViewModel;
using IMDB.Functions;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        IsRated isRated = new IsRated();
        DbData dbData = new DbData();
        DbAdd dbAdd = new DbAdd();
        HomeViewModel homeVm = new HomeViewModel();
        public ActionResult Home()
        {
            var movies = dbData.RetriveMovies();
            var actors = dbData.RetriveActors();
            var directors = dbData.RetriveDirectors();
            return View(movies);
        }

        [HttpGet]
        public ActionResult FilmDetails(String id)
        {
            int movieId = Int32.Parse(id);
            Session["Movie_ID"] = movieId;
            IEnumerable<Comment> comment = dbData.RetrieveFilmComments(movieId);
            Movie movie = dbData.RetriveMovies(movieId);
            int? directorId = movie.Director_ID;
            var movieActors = dbData.RetriveMovieActors(movieId);
            Director director = dbData.RetriveDirectors(directorId);
            FilmDetailsViewModel filmDetailsViewModel = new FilmDetailsViewModel()
            {
                Movie = movie,
                Director = director,
                MovieActors = movieActors,
                Comments = comment,
            };
            if (Session["User_ID"] != null)
            {
                int userId = (int)Session["User_ID"];
                User loggedOnUser = dbData.RetrieveUser(userId);
                Like like = dbData.RetrieveUserMovieLike(loggedOnUser.User_ID, movieId);
                filmDetailsViewModel.User = loggedOnUser;
                filmDetailsViewModel.Like = like;
            }
            return View(filmDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilmDetails(FilmDetailsViewModel filmDetails, int pressedBtn)
        {
            switch (pressedBtn)
            {
                case 1:
                    dbAdd.MovieID= (int)Session["Movie_ID"];
                    dbAdd.UserID = (int)Session["User_ID"];
                    dbAdd.CommentDb(filmDetails.Upcomment.CommentData);
                    break;
                case 2:
                    isRated.MovieID = (int)Session["Movie_ID"];
                    isRated.UserID = (int)Session["User_ID"];
                    var valid = isRated.Validate();

                    if (valid)
                    {
                        isRated.Update(filmDetails.Like.LikeValue);   
                    }
                    else
                    {
                        isRated.Insert(filmDetails.Like.LikeValue);
                    }       
                    break;
            }
            return RedirectToAction("FilmDetails");
        }
    }
}