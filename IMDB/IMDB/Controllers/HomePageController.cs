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
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult FilmDetails()
        {
            
            var movies = _context.Movies.ToList();
            return View(movies);
        }
    }
}