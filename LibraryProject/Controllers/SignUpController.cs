using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    [AllowAnonymous]
    public class SignUpController : Controller
    {
        // GET: SignUp
        DB_LibraryEntities db = new DB_LibraryEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Tbl_Users p)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.Tbl_Users.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}