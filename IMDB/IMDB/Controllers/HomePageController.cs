using IMDB.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using System.Drawing;

namespace IMDB.Controllers
{
    public class HomePageController : Controller
    {
        IMdbDBContext _context = new IMdbDBContext();

        public ActionResult HomePage()
        {
            var data = _context.Movies.ToList();
            Movie movie = new Movie();
            movie = _context.Movies.Find(1);
            byte[] imageData = movie.Img;
            ViewBag.Image = imageData;
            return View(movie);
        }

        public ActionResult FilmDetails()
        {
            return View();
        }
    }
}