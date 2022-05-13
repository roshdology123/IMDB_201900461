using IMDB.DataLayer;
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class LoginRegisterController : Controller
    {
       private IMdbDBContext db = new IMdbDBContext();
        // GET: LoginRegister
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(User log)
        {
           var User=db.Users.Where(x => x.Email == log.Email && x.Password == log.Password).Count();
            if (User>0 && log.Role_ID==0)
            {
                Session["User_ID"]=log.User_ID;

                return RedirectToAction("HomePage", "HomePage");
            }
            else { 
            return RedirectToAction("AdminHomePage","AdminView");
            }
        }
        // GET: Users/Create
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register( User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}