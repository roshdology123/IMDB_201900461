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
    public class HomePageController : Controller
    {
        IMdbDBContext _context = new IMdbDBContext();
        IsRated isRated = new IsRated();
        DbData dbData = new DbData();
        public ActionResult HomePage()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public ActionResult FilmDetails(String ID)
        {
            int MovieID = Int32.Parse(ID);
            Session["Movie_ID"] = MovieID;
            Session["User_ID"] = 2;
            User loggedOnUser = _context.Users.Find(2);
            Movie movie = _context.Movies.Find(MovieID);
            int? directorID = movie.Director_ID;
            var movieActors = _context.MovieActors.ToList().Where(x => MovieID == x.Movie_ID);
            Director director = _context.Directors.Find(directorID);
            IEnumerable<Comment> comment = _context.Comments.ToList().Where(x=> MovieID == x.Movie_ID);
            Like like = _context.Likes.SingleOrDefault(x => MovieID == x.Movie_ID && x.User_ID == 2 );
            

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
        public ActionResult FilmDetails(FilmDetailsViewModel fdvm)
        {
            try
            {
                Comment comment = new Comment();
                comment.CommentData = fdvm.Upcomment.CommentData;       
                comment.Movie_ID = (int)Session["Movie_ID"];
                comment.User_ID = (int)Session["User_ID"];
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isRated.MovieID = (int)Session["Movie_ID"];
                isRated.UserID = (int)Session["User_ID"];
                var valid = isRated.Validate();
                isRated.Update(fdvm.Like.LikeValue);

                //Like like = new Like();
                //like.Movie_ID = (int)Session["Movie_ID"];
                //like.User_ID = (int)Session["User_ID"];
                //like.LikeValue = fdvm.Like.LikeValue;
                //_context.Likes.Add(like);
                //_context.SaveChanges();
            }


            return RedirectToAction("FilmDetails");
        }


        public ActionResult Search(String searching)
        {
            var retrivedActors = dbData.RetriveActors();
            var retrivedDirectors = dbData.RetriveDirectors();
            var retrivedMovies = dbData.RetriveMovies();

            return View();
        }

    }
}