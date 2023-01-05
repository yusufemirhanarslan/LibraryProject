using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace LibraryProject.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Index(int page = 1)
        {
            //var variables = db.Tbl_Users.ToList();
                var variable = db.Tbl_Users.ToList().ToPagedList(page, 3);
                return View(variable);
        }

        [HttpGet]
        public ActionResult AddUsers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUsers(Tbl_Users p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUsers");
            }
            db.Tbl_Users.Add(p);
            db.SaveChanges();
            return View();

        }
        public ActionResult UsersDelete(int id)
        {
            var users = db.Tbl_Users.Find(id);
            db.Tbl_Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CallUsers(int id)
        {
            var users1 = db.Tbl_Users.Find(id);
            return View("CallUsers", users1);
        }

        public ActionResult UpdateUsers(Tbl_Users p)
        {
            var us = db.Tbl_Users.Find(p.ID);
            us.Name = p.Name;
            us.Surname = p.Surname;
            us.Mail = p.Mail;
            us.User_Name = p.User_Name;
            us.Password = p.Password;
            us.School = p.School;
            us.Phone = p.Phone;
            us.Photo = p.Photo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UserBookHistory(int id)
        {
            var bookHistory = db.Tbl_Action.Where(x => x.Users == id).ToList();
            var userBook = db.Tbl_Users.Where(y=>y.ID==id).Select(z=>z.Name+ " "+ z.Surname).FirstOrDefault();
            ViewBag.user = userBook;
            return View(bookHistory);
        }
    }
}