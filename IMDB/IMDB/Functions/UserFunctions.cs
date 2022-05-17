using IMDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Functions
{
    public class UserFunctions
    {
        DbData dbData = new DbData();
        /// <summary>
        /// Assign Actors and its movies into actor Details view model
        /// </summary>
        /// <param name="actorId"></param>
        public void AssignActorsToVm(int actorId)
        {
            ActorDetailsViewModel actorDetailsVm = new ActorDetailsViewModel();
            actorDetailsVm.Actor = dbData.RetriveActors(actorId);
            actorDetailsVm.movieActors = dbData.RetrieveActorMovies(actorId);
        }
    }
}