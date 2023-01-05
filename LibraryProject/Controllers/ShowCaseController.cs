using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LibraryProject.Models.Entity;
using LibraryProject.Models.Class;
namespace LibraryProject.Controllers
{
    [AllowAnonymous]
    public class ShowCaseController : Controller
    {
        // GET: ShowCase
        DB_LibraryEntities db = new DB_LibraryEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.variable1 = db.Tbl_Book.ToList();
            cs.variable2 = db.Tbl_About.ToList();
            //var variables = db.Tbl_Book.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Contect t)
        {
            db.Tbl_Contect.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}