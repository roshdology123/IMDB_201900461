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
        SearchViewModel searchVm = new SearchViewModel();
        // GET: Search
        [HttpGet]
        public ActionResult Search()
        {
            searchVm.Actors = dbData.RetriveActors();
            searchVm.Directors = dbData.RetriveDirectors();
            searchVm.Movies = dbData.RetriveMovies();
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
                    searchVm.Actors = dbData.RetriveActors().Where(actorModel => actorModel.FName.ToLower().StartsWith(item) || actorModel.LName.ToLower().StartsWith(item) || searchValue == null);
                    searchVm.Directors = dbData.RetriveDirectors().Where(directorModel => directorModel.FName.ToLower().StartsWith(item) || directorModel.LName.StartsWith(item) || searchValue == null);
                    searchVm.Movies = dbData.RetriveMovies().Where(movieModel => movieModel.Movie_Name.ToLower().StartsWith(item) || searchValue == null);
                    return View(searchVm);
                }
                return View(searchVm);
            }
        }
    }
}