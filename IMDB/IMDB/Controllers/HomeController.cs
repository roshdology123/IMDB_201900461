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
        IMdbDBContext _context = new IMdbDBContext();
        IsRated isRated = new IsRated();
        DbData dbData = new DbData();
        DbAdd dbAdd = new DbAdd();
        HomeViewModel HomeVM = new HomeViewModel();
        public ActionResult Home()
        {
            var movies = dbData.RetriveMovies();
            var actors = dbData.RetriveActors();
            var directors = dbData.RetriveDirectors();
            

            return View(movies);
        }

        [HttpGet]
        public ActionResult FilmDetails(String ID)
        {
            int MovieID = Int32.Parse(ID);
            Session["Movie_ID"] = MovieID;
            IEnumerable<Comment> comment = dbData.RetrieveFilmComments(MovieID);
            Movie movie = dbData.RetriveMovies(MovieID);
            int? directorID = movie.Director_ID;
            var movieActors = dbData.RetriveMovieActors(MovieID);
            Director director = dbData.RetriveDirectors(directorID);

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
                Like like = dbData.RetrieveUserMovieLike(loggedOnUser.User_ID, MovieID);
                filmDetailsViewModel.User = loggedOnUser;
                filmDetailsViewModel.Like = like;
            }

            return View(filmDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilmDetails(FilmDetailsViewModel fdvm, int PressedBtn)
        {
           
            switch (PressedBtn)
            {
                case 1:
                    dbAdd.MovieID = (int)Session["Movie_ID"];
                    dbAdd.UserID = (int)Session["User_ID"];
                    dbAdd.CommentDb(fdvm.Upcomment.CommentData);
                    break;
                case 2:
                    isRated.MovieID = (int)Session["Movie_ID"];
                    isRated.UserID = (int)Session["User_ID"];
                    var valid = isRated.Validate();

                    if (valid)
                    {
                        isRated.Update(fdvm.Like.LikeValue);
                        
                    }

                    else
                    {
                        isRated.Insert(fdvm.Like.LikeValue);
                    }
                    
                    break;
            }
           


            return RedirectToAction("FilmDetails");
        }




    }
}