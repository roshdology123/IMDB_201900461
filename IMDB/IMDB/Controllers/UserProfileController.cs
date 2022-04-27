using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserSettings
        public ActionResult UserSettings()
        {
            return View();
        }
    }
}