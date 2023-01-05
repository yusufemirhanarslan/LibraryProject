using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
using System.Web.Security;
namespace LibraryProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DB_LibraryEntities db= new DB_LibraryEntities();
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Tbl_Users p)
        {
            var info = db.Tbl_Users.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if(info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Mail, false);
                Session["Mail"] = info.Mail.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
            
        }
    }
}