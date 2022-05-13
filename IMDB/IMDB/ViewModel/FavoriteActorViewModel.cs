using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModel
{
    public class FavoriteActorViewModel
    {
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<UserFActor> favoActors { get; set; }
        public UserFActor FActor { get; set; }
        public Actor Actor { get; set; }

    }
}