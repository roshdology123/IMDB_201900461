using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMDB.Models;

namespace IMDB.ViewModel
{
    public class Movie_Director
    {
        public List<Director> directors { get; set; }
        public Movie movie { get; set; }
    }
}