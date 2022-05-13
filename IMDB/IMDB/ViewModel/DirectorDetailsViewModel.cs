using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;
namespace IMDB.ViewModel
{
    public class DirectorDetailsViewModel
    {
        public Director Director{ get; set; }
        public IEnumerable<Movie> Movies{ get; set; }
    }
}