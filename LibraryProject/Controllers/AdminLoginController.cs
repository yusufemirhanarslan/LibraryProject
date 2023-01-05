using LibraryProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace LibraryProject.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
       DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Tbl_Admin t)
        {
            var variables = db.Tbl_Admin.FirstOrDefault(x => x.AdminUser == t.AdminUser && x.Password == t.Password);
            if(variables != null)
            {
                FormsAuthentication.SetAuthCookie(variables.AdminUser, false);
                Session["AdminUser"] = variables.AdminUser.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
            
        }

    }

        
}