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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User log)
        {

            User User = db.Users.FirstOrDefault(x => x.Email == log.Email && x.Password == log.Password);

            if (log.Email == null || log.Password == null)
            {
                TempData["Message2"] = "Please fill all fields";
                return RedirectToAction("Login");

            }else if(User == null)
            {
                TempData["Message"] = "Wrong email or password";
                return RedirectToAction("Login");
            }
            else if (User.Role_ID == 0)
            {
                Session["User_ID"] = User.User_ID;
                Session["UserName"] = User.FName + " " + User.LName;

                return RedirectToAction("Home", "Home");
            }
            else if(User.Role_ID == 1)
            {
                Session["Admin_ID"] = User.User_ID;

                return RedirectToAction("AdminHomePage", "AdminView");


            }
            else
            {
                TempData["Message"] = "Wrong email or password";
                return RedirectToAction("Login");
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
                if (db.Users.Any(x => x.Email == user.Email))
            {
                ViewBag.Notification = " Account already existed";
              return View();
          
            }
            else 
            {
                db.Users.Add(user);
                db.SaveChanges();

                return View("Login");

            }
            }
            return View();
        }
    }
}