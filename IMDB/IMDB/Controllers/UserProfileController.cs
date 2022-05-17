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
            try
            {
                User user = new User();
                int userId = (int)Session["User_ID"];
                user = db.Users.Find(userId);
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
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProfileSettings");

            }
            return View(user);
        }
        [HttpGet]
        public ActionResult FavoriteActors()
        {
                int userId = (int)Session["User_ID"];
                FavoriteActorViewModel favoActorVM = new FavoriteActorViewModel();
                favoActorVM.favoActors = db.UserFActors.Where(x => x.User_ID == userId);
                favoActorVM.Actors = db.Actors.ToList();
                return View(favoActorVM);
        }
        [HttpPost]
        public ActionResult FavoriteActors(FavoriteActorViewModel favoActorVM, int BtnType)
        {
                int userId = (int)Session["User_ID"];
                switch (BtnType)
                {
                    case 0:
                        var DFActor = db.UserFActors.SingleOrDefault(m => m.Actor_ID == favoActorVM.FActor.Actor_ID && m.User_ID == userId);
                        
                        if (DFActor != null)
                        {
                            db.UserFActors.Remove(DFActor);
                            db.SaveChanges();
                        }
                        else
                        {
                        TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                        break;
                        }
                        break;
                    case 1:
                        int rowsCount = db.UserFActors.Where(fActorModel => fActorModel.Actor_ID == favoActorVM.Actor.Actor_ID && fActorModel.User_ID == userId).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Actor is already in your Favorites";
                        }
                        else
                        {
                            UserFActor UFActor = new UserFActor();
                            UFActor.Actor_ID = favoActorVM.Actor.Actor_ID;
                            UFActor.User_ID = userId;
                        if (UFActor.Actor_ID != 0)
                        {
                            db.UserFActors.Add(UFActor);
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
            FavoriteMovieViewModel favoMovieVM = new FavoriteMovieViewModel();
            favoMovieVM.favoMovies = db.UserFMovies.Where(x => x.User_ID == userId);
            favoMovieVM.Movies = db.Movies.ToList();
            return View(favoMovieVM);
        }
        [HttpPost]
        public ActionResult FavoriteMovies(FavoriteMovieViewModel favoMovieVM, int BtnType)
        {
            int userId = (int)Session["User_ID"];
                switch (BtnType)
                {
                    case 0:
                        var DFMovie = db.UserFMovies.SingleOrDefault(m => m.Movie_ID == favoMovieVM.FMovie.Movie_ID && m.User_ID == userId);
                        if (DFMovie != null)
                        {
                            db.UserFMovies.Remove(DFMovie);
                            db.SaveChanges();
                        }
                        else
                        {
                            TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                            break;
                        }
                        break;
                    case 1:
                        int rowsCount = db.UserFMovies.Where(fMovieModel => fMovieModel.Movie_ID == favoMovieVM.Movie.Movie_ID && fMovieModel.User_ID == userId).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Movie is already in your Favorites";
                        }
                        else
                        {
                            UserFMovie UFMovie = new UserFMovie();
                            UFMovie.Movie_ID = favoMovieVM.Movie.Movie_ID;
                            UFMovie.User_ID = userId;
                            if (UFMovie.Movie_ID != 0)
                            {
                                db.UserFMovies.Add(UFMovie);
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
            FavoriteDirectorViewModel favoDirectorVM = new FavoriteDirectorViewModel();
            favoDirectorVM.favoDirectors = db.UserFDirectors.Where(x => x.User_ID == userId);
            favoDirectorVM.Directors = db.Directors.ToList();
            return View(favoDirectorVM);
        }
        [HttpPost]
        public ActionResult FavoriteDirectors(FavoriteDirectorViewModel favoDirectorVM, int BtnType)
        {
            int userId = (int)Session["User_ID"];

                switch (BtnType)
                {
                    case 0:
                        var DFDirector = db.UserFDirectors.SingleOrDefault(m => m.Director_ID == favoDirectorVM.FDirector.Director_ID && m.User_ID == userId);
                        if (DFDirector != null)
                        {
                            db.UserFDirectors.Remove(DFDirector);
                            db.SaveChanges();
                        }
                        else
                        {
                            TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                            break;
                        }
                        break;
                    case 1:
                        int rowsCount = db.UserFDirectors.Where(fDirectorModel => fDirectorModel.Director_ID == favoDirectorVM.Director.Director_ID && fDirectorModel.User_ID == userId).Count();
                        if (rowsCount > 0)
                        {
                            TempData["Message"] = "This Director is already in your Favorites";
                        }
                        else
                        {
                            UserFDirector UFDirector = new UserFDirector();
                            UFDirector.Director_ID = favoDirectorVM.Director.Director_ID;
                            UFDirector.User_ID = userId;
                            if (UFDirector.Director_ID != 0)
                            {
                                db.UserFDirectors.Add(UFDirector);
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