using IMDB.DataLayer;
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
        private IMdbDBContext db = new IMdbDBContext();
        // GET: AdminHomePage
        public ActionResult AdminHomePage()
        {
            return View();
        }


        // GET: Actors
        public ActionResult Actors()
        {
            List<Actor> Actors = db.Actors.ToList();
            return View(Actors);
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
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Actors");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditActor(int? id)
        {
            if (id != null)
            {
                var actor = db.Actors.SingleOrDefault(a => a.Actor_ID == id);
                if (actor == null)
                {
                    return HttpNotFound();
                }
                Actor ActorData = new Actor
                {
                    Actor_ID = actor.Actor_ID,
                    FName = actor.FName,
                    LName = actor.LName,
                    Age = actor.Age

                };
                return View(ActorData);
            }
            else
            {
                return RedirectToAction("Actors");
            }


        }
        [HttpPost]
        public ActionResult EditActor(Actor actorvar)
        {
            if (ModelState.IsValid)
            {
                var actor = db.Actors.SingleOrDefault(a => a.Actor_ID == actorvar.Actor_ID);
                actor.FName = actorvar.FName;
                actor.LName = actorvar.LName;
                actor.Age = actorvar.Age;
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
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
            Actor actor = db.Actors.Find(id);
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
            Actor actor = db.Actors.Find(id);

            foreach (var item in db.MovieActors.Where(x => x.Actor_ID == id))
            {
                db.MovieActors.Remove(item);
            }

            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Actors");
        }


        public ActionResult Directors()
        {

            List<Director> Directors = db.Directors.ToList();

            return View(Directors);
        }
        public ActionResult AddDirectors()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdddDirectors()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDirectors(Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Directors");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditDirector(int? id)
        {
            if (id != null)
            {
                var director = db.Directors.SingleOrDefault(a => a.Director_ID == id);
                if (director == null)
                {
                    return HttpNotFound();
                }
                Director DirectorData = new Director
                {
                    Director_ID = director.Director_ID,
                    FName = director.FName,
                    LName = director.LName,
                    Age = director.Age

                };
                return View(DirectorData);
            }
            else
            {
                return RedirectToAction("Directors");
            }


        }
        [HttpPost]
        public ActionResult EditDirector(Director directorvar)
        {
            if (ModelState.IsValid)
            {
                var director = db.Directors.SingleOrDefault(a => a.Director_ID == directorvar.Director_ID);
                director.FName = directorvar.FName;
                director.LName = directorvar.LName;
                director.Age = directorvar.Age;
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
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
            Director director = db.Directors.Find(id);
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
            IEnumerable<Movie> movie = db.Movies.Where(a => a.Director_ID == id);
            if (db.Movies.Where(a => a.Director_ID == id).Count() > 0)
            {

                foreach (var sMovies in movie)
                {
                    sMovies.Director_ID = 9;
                }
                Director director = db.Directors.Find(id);
                db.Directors.Remove(director);
                db.SaveChanges();


            }
            else
            {
                Director director = db.Directors.Find(id);
                db.Directors.Remove(director);
                db.SaveChanges();

            }
            return RedirectToAction("Directors");

        }

        public ActionResult Movies()
        {
            List<Movie> Movies = db.Movies.ToList();
            return View(Movies);
        }


        [HttpGet]
        public ActionResult AddMovies()
        {
            var directors = db.Directors.ToList();
            Director defultdirector = new Director();

            directors.RemoveAll(x => x.Director_ID == 9);
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
                    db.Movies.Add(movieDirectorViewModel.movie);
                    db.SaveChanges();
                    return RedirectToAction("Movies");
                }


            }
            var directors = db.Directors.ToList();
            directors.RemoveAll(x => x.Director_ID == 9);
            movieDirectorViewModel.directors = directors;
            return View("AddMovies", movieDirectorViewModel);
        }







        [HttpGet]
        [AllowAnonymous]
        public ActionResult MovieToActor(int? id)
        {

            var actor = db.Actors.ToList();
            var movie = db.Movies.Where(x => x.Movie_ID == id);

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
                var actor = db.Actors.ToList();
                movieAndActor.Actors = actor;

                var movie = db.Movies.ToList();
                movieAndActor.Movies = movie;

                if (db.MovieActors.Where(id => id.Actor_ID == movieAndActor.MovieActor.Actor_ID && id.Movie_ID == movieAndActor.MovieActor.Movie_ID).Count() > 0)
                {

                    TempData["Message"] = "This Actor already existed";
                    return RedirectToAction("MovieToActor");
                }
                db.MovieActors.Add(movieAndActor.MovieActor);
                db.SaveChanges();
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
                var movie = db.Movies.SingleOrDefault(a => a.Movie_ID == id);
                if (movie == null)
                {
                    return HttpNotFound();
                }

                var directors = db.Directors.ToList();
               

                directors.RemoveAll(x => x.Director_ID == 9);
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
        public ActionResult EditMovie(Movie_Director movievar, HttpPostedFileBase MovieImage)
        {
            var movie = db.Movies.SingleOrDefault(a => a.Movie_ID == movievar.movie.Movie_ID);
          
            
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

                movie.Movie_Name = movievar.movie.Movie_Name;
                movie.Movie_TLink = movievar.movie.Movie_TLink;
                
             
                movie.Director_ID = movievar.movie.Director_ID;
               
              
              
             
                    db.Entry(movie).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Movies");
              
            }
            else
            {

                var Directors = db.Directors.ToList();
                Directors.RemoveAll(x => x.Director_ID == 9);
                movievar.directors = Directors;
                movievar.movie = movie;
                return View(movievar);
            }


           
        }




        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
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
            Movie movie = db.Movies.Find(id);

            foreach (var item in db.MovieActors.Where(x => x.Movie_ID == id))
            {
                db.MovieActors.Remove(item);
            }

            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Movies");
        }



    }

}