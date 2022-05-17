using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMDB.DataLayer 
{
    public class IMdbDBContext : DbContext
    {
        public IMdbDBContext(): base("IMDB-app-db")
        {
        }

        
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFActor> UserFActors { get; set; }
        public DbSet<UserFDirector> UserFDirectors { get; set; }
        public DbSet<UserFMovie> UserFMovies { get; set; }
        
    }
    
}
