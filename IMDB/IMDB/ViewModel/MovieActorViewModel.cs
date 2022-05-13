using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModel
{
    public class MovieActorViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }

        public IEnumerable<Actor> Actors { get; set; }

        public MovieActor MovieActor { get; set; }
    }
}