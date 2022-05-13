using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModel
{
    public class FavoriteMovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<UserFMovie> favoMovies { get; set; }
        public UserFMovie FMovie { get; set; }
        public Movie Movie { get; set; }
    }
}