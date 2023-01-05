using LibraryProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryProject.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        DB_LibraryEntities db = new DB_LibraryEntities();
        // GET: Panel
        [HttpGet]
        
        public ActionResult Index()
        {
            var userMail = (string)Session["Mail"];
            var variables = db.Tbl_Users.FirstOrDefault(z => z.Mail == userMail);
            var v1 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.Name).FirstOrDefault();
            ViewBag.v1 = v1;
            
            var v2 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.Surname).FirstOrDefault();
            ViewBag.v2 = v2;

            var v3 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.Photo).FirstOrDefault();
            ViewBag.v3 = v3;

            var v4 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.User_Name).FirstOrDefault();
            ViewBag.v4 = v4;

            var v5 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.School).FirstOrDefault();
            ViewBag.f5 = v5;

            var v6 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.Phone).FirstOrDefault();
            ViewBag.v6 = v6;

            var v7 = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.Mail).FirstOrDefault();
            ViewBag.v7 = v7;

            var userId = db.Tbl_Users.Where(x => x.Mail == userMail).Select(y => y.ID).FirstOrDefault();
            var v8 = db.Tbl_Action.Where(x => x.Users == userId).Count();
            ViewBag.v8 = v8;

            return View(variables);
        }

        [HttpPost]
        public ActionResult Index2(Tbl_Users p)
        {
            var user = (string)Session["Mail"];
            var userInfo = db.Tbl_Users.FirstOrDefault(x => x.Mail == user);
            userInfo.Password = p.Password;
            userInfo.Name = p.Name;
            userInfo.Surname = p.Surname;
            userInfo.Photo = p.Photo;
            userInfo.School = p.School;
            db.SaveChanges();
            return RedirectToAction("Index"); 

        }
        
        public ActionResult MyBooks()
        {
            var user = (string)Session["Mail"];
            var id = db.Tbl_Users.Where(x => x.Mail == user.ToString()).Select(z => z.ID).FirstOrDefault();
            var variables = db.Tbl_Action.Where(x => x.Users == id).ToList();
            return View(variables);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            //return RedirectToAction("SignIn","Login");
            return RedirectToAction("Login","AdminLogin");
        }
    }
}