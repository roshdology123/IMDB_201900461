using IMDB.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using System.Data.Entity;
using System.IO;
using IMDB.ViewModel;

namespace IMDB.Controllers
{
    public class UserProfileController : Controller
    {
        private IMdbDBContext db = new IMdbDBContext();
        // GET: UserSettings
        [HttpGet]
        public ActionResult ProfileSettings()
        {
            User user = new User();
            user = db.Users.Find(2);
            Session["User_Img"] = user.User_Img;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileSettings([Bind(Include = "User_ID,Email,Password,FName,LName,Role_ID,User_Img")] User user, HttpPostedFileBase profileImg)
        {
            if (ModelState.IsValid)
            {

                MemoryStream ms = new MemoryStream();
                if (profileImg != null)
                {
                    profileImg.InputStream.CopyTo(ms);
                    byte[] profileArray = ms.ToArray();
                    user.User_Img = profileArray;
                }
                else
                {
                    user.User_Img = (byte[])Session["User_Img"];
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfileSettings");

            }
            return View(user);
        }
        [HttpGet]
        public ActionResult FavoriteActors()
        {
            if (ModelState.IsValid)
            {
                FavoriteActorViewModel favoActorVM = new FavoriteActorViewModel();
                favoActorVM.favoActors = db.UserFActors.Where(x => x.User_ID == 2);
                favoActorVM.Actors = db.Actors.ToList();
                return View(favoActorVM);
            }
            return View();
        }
        [HttpPost]
        public ActionResult FavoriteActors(FavoriteActorViewModel favoActorVM, int BtnType)
        {
            if (ModelState.IsValid)
            {
                int UserID = 2;

                switch (BtnType)
                {
                    case 0:
                        var DFActor = db.UserFActors.SingleOrDefault(m => m.Actor_ID == favoActorVM.FActor.Actor_ID);
                        db.UserFActors.Remove(DFActor);
                        db.SaveChanges();
                        break;
                    case 1:
                        int rowsCount = db.UserFActors.Where(fActorModel => fActorModel.Actor_ID == favoActorVM.Actor.Actor_ID && fActorModel.User_ID == UserID).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Actor is already in your Favorites";
                        }
                        else
                        {
                            UserFActor UFActor = new UserFActor();
                            UFActor.Actor_ID = favoActorVM.Actor.Actor_ID;
                            //TODO
                            UFActor.User_ID = 2;
                            db.UserFActors.Add(UFActor);
                            db.SaveChanges();
                        }
                        break;
                }
                return RedirectToAction("FavoriteActors");
            }
            return View();
        }
        [HttpGet]
        public ActionResult FavoriteMovies()
        {
            FavoriteMovieViewModel favoMovieVM = new FavoriteMovieViewModel();
            //TODO
            favoMovieVM.favoMovies = db.UserFMovies.Where(x => x.User_ID == 2);
            favoMovieVM.Movies = db.Movies.ToList();
            return View(favoMovieVM);
        }
        [HttpPost]
        public ActionResult FavoriteMovies(FavoriteMovieViewModel favoMovieVM, int BtnType)
        {
            int UserID = 2;

            switch (BtnType)
            {
                case 0:
                    var DFMovie = db.UserFMovies.SingleOrDefault(m => m.Movie_ID == favoMovieVM.FMovie.Movie_ID);
                    db.UserFMovies.Remove(DFMovie);
                    db.SaveChanges();
                    break;
                case 1:
                    int rowsCount = db.UserFMovies.Where(fMovieModel => fMovieModel.Movie_ID == favoMovieVM.Movie.Movie_ID && fMovieModel.User_ID == UserID).Count();
                    if (rowsCount > 0)
                    {
                        TempData["Message"] = "This Movie is already in your Favorites";
                    }
                    else
                    {
                        UserFMovie UFMovie = new UserFMovie();
                        UFMovie.Movie_ID = favoMovieVM.Movie.Movie_ID;
                        //TODO
                        UFMovie.User_ID = 2;
                        db.UserFMovies.Add(UFMovie);
                        db.SaveChanges();
                    }
                    break;
            }
            return RedirectToAction("FavoriteMovies");
        }
        [HttpGet]
        public ActionResult FavoriteDirectors()
        {
            FavoriteDirectorViewModel favoDirectorVM = new FavoriteDirectorViewModel();
            favoDirectorVM.favoDirectors = db.UserFDirectors.Where(x => x.User_ID == 2);
            favoDirectorVM.Directors = db.Directors.ToList();
            return View(favoDirectorVM);
        }
        [HttpPost]
        public ActionResult FavoriteDirectors(FavoriteDirectorViewModel favoDirectorVM, int BtnType)
        {
            int UserID = 2;

            switch (BtnType)
            {
                case 0:
                    var DFDirector = db.UserFDirectors.SingleOrDefault(m => m.Director_ID == favoDirectorVM.FDirector.Director_ID);
                    db.UserFDirectors.Remove(DFDirector);
                    db.SaveChanges();
                    break;
                case 1:
                    int rowsCount = db.UserFDirectors.Where(fDirectorModel => fDirectorModel.Director_ID == favoDirectorVM.Director.Director_ID && fDirectorModel.User_ID == UserID).Count();
                    if (rowsCount > 0)
                    {
                        TempData["Message"] = "This Director is already in your Favorites";
                    }
                    else
                    {
                        UserFDirector UFDirector = new UserFDirector();
                        UFDirector.Director_ID = favoDirectorVM.Director.Director_ID;
                        //TODO
                        UFDirector.User_ID = 2;
                        db.UserFDirectors.Add(UFDirector);
                        db.SaveChanges();
                    }
                    break;
            }
            return RedirectToAction("FavoriteDirectors");
        }
    }

}