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
           var User=db.Users.FirstOrDefault(x => x.Email == log.Email && x.Password == log.Password);
            if (log.Role_ID==0)
            {
                Session["User_ID"] = User.User_ID;
                Session["UserName"] = User.FName + " " + User.LName;

                return RedirectToAction("Home", "Home");
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