using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{

    public class DbData
    {
        IMdbDBContext _context = new IMdbDBContext();

        private IEnumerable<Actor> Actors { get; set; }
        private IEnumerable<Movie> Movies { get; set; }
        private IEnumerable<Director> Directors { get; set; }

        public IEnumerable<Actor> RetriveActors()
        {
            Actors = _context.Actors;
            return Actors;
        }

        public IEnumerable<Movie> RetriveMovies()
        {
            Movies = _context.Movies;
            return Movies;
        }

        public IEnumerable<Director> RetriveDirectors()
        {
            Directors = _context.Directors;
            return Directors;
        }
    }
}