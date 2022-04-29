﻿using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.ViewModel
{
    public class FilmDetailsViewModel
    {
        public Movie Movie { get; set; }
        public Director Director { get; set; }
        public IEnumerable<Actor> Actor { get; set; }
    }
}