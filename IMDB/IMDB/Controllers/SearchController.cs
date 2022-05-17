using IMDB.DataLayer;
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
        SearchViewModel searchVm = new SearchViewModel();
        // GET: Search
        [HttpGet]
        public ActionResult Search()
        {
            searchVm.Actors = _context.Actors.ToList();
            searchVm.Directors = _context.Directors.ToList();
            searchVm.Movies = _context.Movies.ToList();
            return View(searchVm);
        }


        [HttpPost]
        public ActionResult Search(string searchValue)
        {
            if(searchValue == null || searchValue == "")
            {
                return View(searchVm);
            }
            else {

                string[] searchSplit = searchValue.Split(' ');
                foreach(var item in searchSplit) {
                    searchVm.Actors = _context.Actors.Where(ActorModel => ActorModel.FName.ToLower().StartsWith(item) || ActorModel.LName.ToLower().StartsWith(item) || searchValue == null);
                    searchVm.Directors = _context.Directors.Where(DirectorModel => DirectorModel.FName.ToLower().StartsWith(item) || DirectorModel.LName.StartsWith(item) || searchValue == null);
                    searchVm.Movies = _context.Movies.Where(MovieModel => MovieModel.Movie_Name.ToLower().StartsWith(item) || searchValue == null);
                    return View(searchVm);
                }
                return View(searchVm);
            }
        }
    }
}