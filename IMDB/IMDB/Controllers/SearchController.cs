﻿using IMDB.DataLayer;
using IMDB.Functions;
using IMDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class SearchController : Controller
    {
        DbData dbData = new DbData();
        IMdbDBContext _context = new IMdbDBContext();
        SearchViewModel searchVM = new SearchViewModel();
        // GET: Search
        [HttpGet]
        public ActionResult Search()
        {
            searchVM.Actors = _context.Actors.ToList();
            searchVM.Directors = _context.Directors.ToList();
            searchVM.Movies = _context.Movies.ToList();
            return View(searchVM);
        }


        [HttpPost]
        public ActionResult Search(string SearchValue)
        {
            if(SearchValue == null || SearchValue == "")
            {

            }
            else {

                string[] SearchSplit = SearchValue.Split(' ');
                foreach(var item in SearchSplit) { 
                searchVM.Actors = _context.Actors.Where(ActorModel => ActorModel.FName.StartsWith(item) || ActorModel.LName.StartsWith(item) || SearchValue == null);
                searchVM.Directors = _context.Directors.Where(DirectorModel => DirectorModel.FName.StartsWith(item) || DirectorModel.LName.StartsWith(item) || SearchValue == null);
                searchVM.Movies = _context.Movies.Where(MovieModel => MovieModel.Movie_Name.StartsWith(item) || SearchValue == null);
                }
            }
            return View(searchVM);
        }
    }
}