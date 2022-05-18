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
using IMDB.Functions;

namespace IMDB.Controllers
{
    public class UserProfileController : Controller
    {
        DbData dbData = new DbData();
        DbUpdate dbUpdate = new DbUpdate();
        // GET: UserSettings
        [HttpGet]
        public ActionResult ProfileSettings()
        {
            try
            {
                User user = new User();
                int userId = (int)Session["User_ID"];
                user = dbData.RetrieveUser(userId);
                Session["User_Img"] = user.User_Img;
                return View(user);
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "LoginRegister");
                throw;
            }
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
                dbUpdate.UserDb(user);
                return RedirectToAction("ProfileSettings");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult FavoriteActors()
        {
                int userId = (int)Session["User_ID"];
                FavoriteActorViewModel favoActorVm = new FavoriteActorViewModel();
            favoActorVm.favoActors = db.UserFActors.Where(x => x.User_ID == userId);
            favoActorVm.Actors = dbData.RetriveActors().ToList();
                return View(favoActorVm);
        }

        [HttpPost]
        public ActionResult FavoriteActors(FavoriteActorViewModel favoActorVm, int btnType)
        {
                int userId = (int)Session["User_ID"];
                switch (btnType)
                {
                    case 0:
                        var deleteFavoActor = db.SingleOrDefault(m => m.Actor_ID == favoActorVm.FActor.Actor_ID && m.User_ID == userId);
                        
                        if (deleteFavoActor != null)
                        {
                            db.UserFActors.Remove(deleteFavoActor);
                            db.SaveChanges();
                        }
                        else
                        {
                        TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                        break;
                        }
                        break;
                    case 1:
                        int rowsCount = db.UserFActors.Where(favActorModel => favActorModel.Actor_ID == favoActorVm.Actor.Actor_ID && favActorModel.User_ID == userId).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Actor is already in your Favorites";
                        }
                        else
                        {
                            UserFActor userFavoActor = new UserFActor();
                        userFavoActor.Actor_ID = favoActorVm.Actor.Actor_ID;
                        userFavoActor.User_ID = userId;
                        if (userFavoActor.Actor_ID != 0)
                        {
                            db.UserFActors.Add(userFavoActor);
                            db.SaveChanges();
                        }
                        else
                        {
                            TempData["ErrorChooseAddDropList"] = "Please choose from DropList";
                            break;
                        }
                        }
                        break;
                }
                return RedirectToAction("FavoriteActors");
            }

        [HttpGet]
        public ActionResult FavoriteMovies()
        {
            int userId = (int)Session["User_ID"];
            FavoriteMovieViewModel favoMovieVm = new FavoriteMovieViewModel();
            favoMovieVm.favoMovies = db.UserFMovies.Where(x => x.User_ID == userId);
            favoMovieVm.Movies = db.Movies.ToList();
            return View(favoMovieVm);
        }

        [HttpPost]
        public ActionResult FavoriteMovies(FavoriteMovieViewModel favoMovieVm, int btnType)
        {
            int userId = (int)Session["User_ID"];
                switch (btnType)
                {
                    case 0:
                        var deleteFavoMovie = db.UserFMovies.SingleOrDefault(m => m.Movie_ID == favoMovieVm.FMovie.Movie_ID && m.User_ID == userId);
                        if (deleteFavoMovie != null)
                        {
                            db.UserFMovies.Remove(deleteFavoMovie);
                            db.SaveChanges();
                        }
                        else
                        {
                            TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                            break;
                        }
                        break;
                    case 1:
                        int rowsCount = db.UserFMovies.Where(favoMovieModel => favoMovieModel.Movie_ID == favoMovieVm.Movie.Movie_ID && favoMovieModel.User_ID == userId).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Movie is already in your Favorites";
                        }
                        else
                        {
                            UserFMovie userFavoMovie = new UserFMovie();
                        userFavoMovie.Movie_ID = favoMovieVm.Movie.Movie_ID;
                        userFavoMovie.User_ID = userId;
                            if (userFavoMovie.Movie_ID != 0)
                            {
                                db.UserFMovies.Add(userFavoMovie);
                                db.SaveChanges();
                            }
                            else
                            {
                                TempData["ErrorChooseAddDropList"] = "Please choose from DropList";
                                break;
                            }
                        }
                        break;
                }
                return RedirectToAction("FavoriteMovies");
            }

        [HttpGet]
        public ActionResult FavoriteDirectors()
        {
            int userId = (int)Session["User_ID"];
            FavoriteDirectorViewModel favoDirectorVm = new FavoriteDirectorViewModel();
            favoDirectorVm.favoDirectors = db.UserFDirectors.Where(x => x.User_ID == userId);
            favoDirectorVm.Directors = db.Directors.ToList();
            return View(favoDirectorVm);
        }

        [HttpPost]
        public ActionResult FavoriteDirectors(FavoriteDirectorViewModel favoDirectorVm, int btnType)
        {
            int userId = (int)Session["User_ID"];
                switch (btnType)
                {
                    case 0:
                        var deleteFavoDirector = db.UserFDirectors.SingleOrDefault(m => m.Director_ID == favoDirectorVm.FDirector.Director_ID && m.User_ID == userId);
                        if (deleteFavoDirector != null)
                        {
                            db.UserFDirectors.Remove(deleteFavoDirector);
                            db.SaveChanges();
                        }
                        else
                        {
                            TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                            break;
                        }
                        break;
                    case 1:
                        int rowsCount = db.UserFDirectors.Where(favoDirectorModel => favoDirectorModel.Director_ID == favoDirectorVm.Director.Director_ID && favoDirectorModel.User_ID == userId).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Director is already in your Favorites";
                        }
                        else
                        {
                            UserFDirector userFavoDirector = new UserFDirector();
                        userFavoDirector.Director_ID = favoDirectorVm.Director.Director_ID;
                        userFavoDirector.User_ID = userId;
                            if (userFavoDirector.Director_ID != 0)
                            {
                                db.UserFDirectors.Add(userFavoDirector);
                                db.SaveChanges();
                            }
                            else
                            {
                                TempData["ErrorChooseAddDropList"] = "Please choose from DropList";
                                break;
                            }
                        }
                        break;
                }
                return RedirectToAction("FavoriteDirectors");
            }
    }
}