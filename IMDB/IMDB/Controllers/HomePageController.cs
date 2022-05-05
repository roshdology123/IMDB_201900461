using IMDB.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using System.Drawing;
using IMDB.ViewModel;

namespace IMDB.Controllers
{
    public class HomePageController : Controller
    {
        IMdbDBContext _context = new IMdbDBContext();

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
            
            User loggedOnUser = _context.Users.Find(2);
            Movie movie = _context.Movies.Find(MovieID);
            int? directorID = movie.Director_ID;
            var movieActors = _context.MovieActors.ToList().Where(x => MovieID == x.Movie_ID);
            Director director = _context.Directors.Find(directorID);
            IEnumerable<Comment> comment = _context.Comments.ToList().Where(x=> MovieID == x.Movie_ID);
            Like like = _context.Likes.Single(x => MovieID == x.Movie_ID && x.User_ID == 2 );

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
        public ActionResult FilmDetails(Comment comment)
        {
            comment.Movie_ID = (int) Session["Movie_ID"];
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("FilmDetails");
        }
    }
}