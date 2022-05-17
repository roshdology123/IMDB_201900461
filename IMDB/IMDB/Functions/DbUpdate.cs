using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{
    public class DbUpdate
    {

        private IMdbDBContext context = new IMdbDBContext();
        public void ActorDb(Actor actor)
        {
            context.Entry(actor).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DirectorDb(Director director)
        {
            context.Entry(director).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void MovieDb(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void UserDb(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}