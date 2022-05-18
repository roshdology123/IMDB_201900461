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
        ActorDetailsViewModel actorDetailsVm = new ActorDetailsViewModel();
        DirectorDetailsViewModel directorDetailsVm = new DirectorDetailsViewModel();
        public ActionResult ActorDetails(string id)
        {
            int actorId = Int32.Parse(id);
            ActorDetailsViewModel actorDetailsVm = new ActorDetailsViewModel();
            actorDetailsVm.Actor = dbData.RetriveActors(actorId);
            actorDetailsVm.movieActors = dbData.RetrieveActorMovies(actorId);
            return View(actorDetailsVm);
        }
        
        public ActionResult DirectorDetails(string id)
        {
            int directorId = Int32.Parse(id);
            DirectorDetailsViewModel directorDetailsVm = new DirectorDetailsViewModel();
            directorDetailsVm.Director = dbData.RetriveDirectors(directorId);
            directorDetailsVm.Movies = dbData.RetrieveDirectorMovies(directorId);
            return View(directorDetailsVm);
        }
    }
}