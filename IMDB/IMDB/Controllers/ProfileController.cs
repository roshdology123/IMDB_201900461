using IMDB.Functions;
using IMDB.Models;
using IMDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        DbData dbData = new DbData();
        ActorDetailsViewModel actorDetailsVM = new ActorDetailsViewModel();
        DirectorDetailsViewModel directorDetailsVM = new DirectorDetailsViewModel();
        public ActionResult ActorDetails(string id)
        {

            int actorId =  Int32.Parse(id);
            actorDetailsVM.Actor = dbData.RetriveActors(actorId);
            actorDetailsVM.movieActors = dbData.RetrieveActorMovies(actorId);

            return View(actorDetailsVM);
        }



        public ActionResult DirectorDetails(string id)
        {
            int directorId = Int32.Parse(id);
            directorDetailsVM.Director = dbData.RetriveDirectors(directorId);
            directorDetailsVM.Movies = dbData.RetrieveDirectorMovies(directorId);

            return View(directorDetailsVM);
        }
    }
}