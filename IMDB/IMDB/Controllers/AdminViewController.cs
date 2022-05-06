using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class AdminViewController : Controller
    {
        private IMdbDBContext db = new IMdbDBContext();
        // GET: AdminHomePage
        public ActionResult AdminHomePage()
        {
            return View();
        }
        public ActionResult Movies()
        {
            return View();
        }
        public ActionResult AddMovies()
        {
            return View();
        }
        
        // GET: Actors
        public ActionResult Actors()
        {
            List<Actor> Actors = db.Actors.ToList();
            return View(Actors);
        }

        [HttpGet]
        public ActionResult AddActors()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddActors(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Actors");
            }
            return View();
        }

        public ActionResult Directors()
        {
            List<Director> Directors = db.Directors.ToList();
            return View(Directors);
        }
        public ActionResult AddDirectors()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdddDirectors()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDirectors(Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Directors");
            }
            return View();
        }
    }
}