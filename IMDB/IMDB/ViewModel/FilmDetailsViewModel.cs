using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModel
{
    public class FilmDetailsViewModel
    {
        public User User { get; set; }
        public Movie Movie { get; set; }
        public Director Director { get; set; }
        public IEnumerable<MovieActor> MovieActors { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Like Like { get; set; }
        public Comment Upcomment{ get; set; }
    }
}