using IMDB.DataLayer;
using IMDB.Functions;
using IMDB.Models;
using IMDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class AdminViewController : Controller
    {
        DbData dbData = new DbData();
        DbAdd dbAdd = new DbAdd();
        DbDelete dbDelete = new DbDelete();
        DbUpdate dbUpdate = new DbUpdate();
        // GET: AdminHomePage
        public ActionResult AdminHomePage()
        {
            return View();
        }


        // GET: Actors
        public ActionResult Actors()
        {
            IEnumerable<Actor> actors = dbData.RetriveActors();
            return View(actors);
        }

        [HttpGet]
        public ActionResult AddActors()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddActors(Actor actor)
        {
            if (ModelState.IsValid)
            {
                dbAdd.ActorDb(actor);
                return RedirectToAction("Actors");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditActor(int? id)
        {
            if (id != null)
            {
                Actor actor = dbData.RetriveActors(id);
                if (actor == null)
                {
                    return HttpNotFound();
                }

                return View(actor);
            }
            else
            {
                return RedirectToAction("Actors");
            }


        }
        [HttpPost]
        public ActionResult EditActor(Actor actorModel)
        {
            if (ModelState.IsValid)
            {
                var searchedActor = dbData.RetriveActors(actorModel.Actor_ID);
                searchedActor.FName = actorModel.FName;
                searchedActor.LName = actorModel.LName;
                searchedActor.Age = actorModel.Age;
                dbUpdate.ActorDb(searchedActor);
                return RedirectToAction("Actors");
            }
            return View();




        }



        // GET: Actors/Delete/5
        public ActionResult DeleteActor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = dbData.RetriveActors(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("DeleteActor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteActorConfirmed(int id)
        {
            Actor actor = dbData.RetriveActors(id);

            foreach (var item in dbData.RetrieveActorMovies(id))
            {
                dbDelete.ActorMoviesDb(item);
            }
            dbDelete.ActorDb(actor);

            return RedirectToAction("Actors");
        }


        public ActionResult Directors()
        {

            IEnumerable<Director> Directors = dbData.RetriveDirectors();

            return View(Directors);
        }
        [HttpGet]
        public ActionResult AddDirectors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDirectors(Director director)
        {
            if (ModelState.IsValid)
            {
                dbAdd.DirectorDb(director);
                return RedirectToAction("Directors");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditDirector(int? id)
        {
            if (id != null)
            {
                var director = dbData.RetriveDirectors(id);
                if (director == null)
                {
                    return HttpNotFound();
                }
                return View(director);
            }
            else
            {
                return RedirectToAction("Directors");
            }


        }
        [HttpPost]
        public ActionResult EditDirector(Director directorModel)
        {
            if (ModelState.IsValid)
            {
                var director = dbData.RetriveDirectors(directorModel.Director_ID);
                dbUpdate.DirectorDb(directorModel);
                return RedirectToAction("Directors");

            }
            return View();

        }

        // GET: Directors/Delete/5
        public ActionResult DeleteDirector(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = dbData.RetriveDirectors(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("DeleteDirector")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDirectorConfirmed(int id)
        {
            IEnumerable<Movie> movie = dbData.RetrieveDirectorMovies(id);
            if (dbData.RetrieveDirectorMoviesCount(id) > 0)
            {

                foreach (var sMovies in movie)
                {
                    sMovies.Director_ID = 4;
                }
                Director director = dbData.RetriveDirectors(id);
                dbDelete.DirectorDb(director);


            }
            else
            {
                Director director = dbData.RetriveDirectors(id);
                dbDelete.DirectorDb(director);

            }
            return RedirectToAction("Directors");

        }

        public ActionResult Movies()
        {
            IEnumerable<Movie> Movies = dbData.RetriveMovies();
            return View(Movies);
        }


        [HttpGet]
        public ActionResult AddMovies()
        {
            var directors = dbData.RetriveDirectors().ToList();
            Director defultdirector = new Director();

            directors.RemoveAll(x => x.Director_ID == 4);
            Movie_Director movieDirector = new Movie_Director
            {
                directors = directors,
            };
            return View(movieDirector);
        }
        [HttpPost]
        public ActionResult AddMovies(Movie_Director movieDirectorViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    TempData["Message"] = "Please choose image";
                    
                }
                else
                {
                    MemoryStream target = new MemoryStream();
                    image.InputStream.CopyTo(target);
                    byte[] movieImageByteArray = target.ToArray();

                    movieDirectorViewModel.movie.Img = movieImageByteArray;
                    dbAdd.MovieDb(movieDirectorViewModel.movie);
                    return RedirectToAction("Movies");
                }


            }
            var directors = dbData.RetriveDirectors().ToList();
            directors.RemoveAll(x => x.Director_ID == 4);
            movieDirectorViewModel.directors = directors;
            return View("AddMovies", movieDirectorViewModel);
        }







        [HttpGet]
        [AllowAnonymous]
        public ActionResult MovieToActor(int? id)
        {

            var actor = dbData.RetriveActors();
            var movie = dbData.SearchMovies(id);

            MovieActorViewModel movieAndActor = new MovieActorViewModel()
            {
                Actors = actor,
                Movies = movie
            };


            return View(movieAndActor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieToActor(MovieActorViewModel movieAndActor)
        {

            if (ModelState.IsValid)
            {
                var actor = dbData.RetriveActors();
                movieAndActor.Actors = actor;

                var movie = dbData.RetriveMovies();
                movieAndActor.Movies = movie;

                if (dbData.MovieActors.Where(id => id.Actor_ID == movieAndActor.MovieActor.Actor_ID && id.Movie_ID == movieAndActor.MovieActor.Movie_ID).Count() > 0)
                {

                    TempData["Message"] = "This Actor already existed";
                    return RedirectToAction("MovieToActor");
                }
                dbAdd.MovieActor(movieAndActor.MovieActor);
                return RedirectToAction("Movies");

            }
            else
            {
                TempData["Message2"] = "Please choose the actor and movie";

                return RedirectToAction("MovieToActor");
            }
        }

        [HttpGet]
        public ActionResult EditMovie(int? id)
        {
            if (id != null)
            {
                var movie = dbData.RetriveMovies(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }

                var directors = dbData.RetriveDirectors().ToList();
               

                directors.RemoveAll(x => x.Director_ID == 4);
                Movie_Director movieDirector = new Movie_Director
                {
                    directors = directors,
                    movie = movie
                };

                
              

                Session["Movie_Img"] = movie.Img;
                return View(movieDirector);
            }
            else
            {
                return RedirectToAction("Movies");
            }


        }
        [HttpPost]
        public ActionResult EditMovie(Movie_Director movieVar, HttpPostedFileBase MovieImage)
        {
            var movie = dbData.RetriveMovies(movieVar.movie.Movie_ID);
          
            
            if (ModelState.IsValid)
            {
                MemoryStream ms = new MemoryStream();
                if (MovieImage != null)
                {
                    MovieImage.InputStream.CopyTo(ms);
                    byte[] profileArray = ms.ToArray();
                    movie.Img = profileArray;
                }
                else
                {
                    movie.Img = (byte[])Session["Movie_Img"];
                }

                movie.Movie_Name = movieVar.movie.Movie_Name;
                movie.Movie_TLink = movieVar.movie.Movie_TLink;
                
             
                movie.Director_ID = movieVar.movie.Director_ID;




                dbUpdate.MovieDb(movie);
                    return RedirectToAction("Movies");
              
            }
            else
            {

                var Directors = dbData.RetriveDirectors().ToList();
                Directors.RemoveAll(x => x.Director_ID == 4);
                movieVar.directors = Directors;
                movieVar.movie = movie;
                return View(movieVar);
            }


           
        }




        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = dbData.RetriveMovies(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = dbData.RetriveMovies(id);

            foreach (var item in dbData.RetriveMovieActors(id))
            {
                dbDelete.ActorMoviesDb(item);
            }
            foreach (var item in dbData.RetrieveFilmComments(id))
            {
                dbDelete.FilmComments(item);
            }
            foreach (var item in dbData.RetrieveMovieLikes(id))
            {
                dbDelete.FilmLikes(item);
            }
            dbDelete.MovieDb(movie);
            
            return RedirectToAction("Movies");
        }

        

    }

}