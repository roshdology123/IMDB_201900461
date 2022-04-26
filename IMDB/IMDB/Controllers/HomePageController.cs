
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IMDB.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult HomePage()
        {
            
            
            return View();
        }
        public ActionResult FilmDetails()
        {
            return View();
        }
    }
}