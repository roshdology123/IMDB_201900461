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
        DbDelete dbDelete = new DbDelete();
        DbAdd dbAdd = new DbAdd();
        IMdbDBContext db = new IMdbDBContext();
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
            favoActorVm.favoActors = dbData.RetrieveUserFActor(userId);
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
                    var deleteFavoActor = dbData.RetrieveUserFActor(userId, favoActorVm.Actor.Actor_ID);


                        if (deleteFavoActor != null)
                    {
                         dbDelete.UserFActorDb(deleteFavoActor);
                    }
                    else
                        {
                        TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                        break;
                        }
                        break;
                case 1:
                    int rowsCount = dbData.UserFActorCountDb(favoActorVm, userId);
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
                            dbAdd.UserFActorDb(userFavoActor);
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
            favoMovieVm.favoMovies = dbData.RetrieveUserFMovie(userId);
            favoMovieVm.Movies = dbData.RetriveMovies();
            return View(favoMovieVm);
        }

        [HttpPost]
        public ActionResult FavoriteMovies(FavoriteMovieViewModel favoMovieVm, int btnType)
        {
            int userId = (int)Session["User_ID"];
                switch (btnType)
                {
                case 0:
                    UserFMovie deleteFavoMovie = dbData.RetrieveUserFMovie(favoMovieVm.FMovie.Movie_ID, userId);
                    if (deleteFavoMovie != null)
                    {
                        dbDelete.UserFMovieDb(deleteFavoMovie);
                    }
                    else
                    {
                        TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                        break;
                    }
                    break;
                case 1:
                    int rowsCount = dbData.UserFMoviesCount(favoMovieVm, userId);
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
                            dbAdd.UserFMovieDb(userFavoMovie);
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
                    UserFDirector deleteFavoDirector = dbData.UserFDirectorDb(favoDirectorVm, userId);
                    if (deleteFavoDirector != null)
                    {
                        dbDelete.UserFDirectorDb(deleteFavoDirector);
                    }
                    else
                    {
                        TempData["ErrorChooseRemoveDropList"] = "Please choose from DropList";
                        break;
                    }
                    break;
                case 1:
                    int rowsCount = dbData.UserFDirectorCount(favoDirectorVm, userId);
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
                            dbAdd.UserFDirectorDb(userFavoDirector);
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