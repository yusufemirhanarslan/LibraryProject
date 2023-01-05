using LibraryProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    [AllowAnonymous]
    public class SettingsController : Controller
    {
        DB_LibraryEntities db = new DB_LibraryEntities();
        // GET: Settings
        public ActionResult Index()
        {
            var adminUser = db.Tbl_Admin.ToList();
            return View();
        }
        public ActionResult Index2()
        {
            var adminUser = db.Tbl_Admin.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAdmin(Tbl_Admin t)
        {
            db.Tbl_Admin.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var admin = db.Tbl_Admin.Find(id);
            db.Tbl_Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var admin = db.Tbl_Admin.Find(id);
            return View("UpdateAdmin", admin);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Tbl_Admin t)
        {
            var admin = db.Tbl_Admin.Find(t.ID);
            admin.AdminUser = t.AdminUser;
            admin.Password = t.Password;
            admin.Authority = t.Authority;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}