using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModel
{
    public class FavoriteDirectorViewModel
    {
        public IEnumerable<Director> Directors { get; set; }
        public IEnumerable<UserFDirector> favoDirectors { get; set; }
        public UserFDirector FDirector { get; set; }
        public Director Director { get; set; }
    }
}