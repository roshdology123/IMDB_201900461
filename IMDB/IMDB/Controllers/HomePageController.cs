﻿using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class HomePageController : Controller
    {
        
        // GET: HomePage
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