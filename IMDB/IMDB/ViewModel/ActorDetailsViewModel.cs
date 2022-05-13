using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModel
{
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}