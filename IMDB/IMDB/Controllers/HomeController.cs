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
            Session["User_ID"] = 2;
            User loggedOnUser = dbData.RetrieveUser(2);
            Movie movie = dbData.RetriveMovies(MovieID);

            int? directorID = movie.Director_ID;

            var movieActors = dbData.RetriveMovieActors(MovieID);

            Director director = dbData.RetriveDirectors(directorID);

            IEnumerable<Comment> comment = dbData.RetrieveFilmComments(MovieID);

            Like like = dbData.RetrieveUserMovieLike(loggedOnUser.User_ID,MovieID);
            

            FilmDetailsViewModel filmDetailsViewModel = new FilmDetailsViewModel()
            {
                User = loggedOnUser,
                Movie = movie,
                Director = director,
                MovieActors = movieActors,
                Comments = comment,
                Like = like
            };

            return View(filmDetailsViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilmDetails(FilmDetailsViewModel fdvm, int PressedBtn)
        {
           
            switch (PressedBtn)
            {
                case 1:
                    Comment comment = new Comment();
                    comment.CommentData = fdvm.Upcomment.CommentData;       
                    comment.Movie_ID = (int)Session["Movie_ID"];
                    comment.User_ID = (int)Session["User_ID"];
                    _context.Comments.Add(comment);
                    _context.SaveChanges();
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