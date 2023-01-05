using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;

namespace LibraryProject.Controllers
{
    public class StatictisController : Controller
    {
        // GET: Statictis
        DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Index()
        {
            var variables1 = db.Tbl_Users.Count();
            var variables2 = db.Tbl_Book.Count();
            var variables3 = db.Tbl_Book.Where(x => x.Check == false).Count();
            var variables4 = db.Tbl_Punishment.Sum(x => x.Money);
            ViewBag.dgr1 = variables1;
            ViewBag.dgr2 = variables2;
            ViewBag.dgr3 = variables3;
            ViewBag.dgr4 = variables4;
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadphoto(HttpPostedFileBase file)
        {
            if(file.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/web2/resimler"), Path.GetFileName(file.FileName));
                file.SaveAs(filePath);
            }

            return RedirectToAction("Gallery");
        }

        public ActionResult LinqCard()
        {
            var variable1 = db.Tbl_Book.Count();
            ViewBag.dgr1 = variable1;

            var variable2 = db.Tbl_Users.Count();
            ViewBag.dgr2 = variable2;

            var variable3 = db.Tbl_Punishment.Sum(x => x.Money);
            ViewBag.dgr3 = variable3;

            var variable4 = db.Tbl_Book.Where(x => x.Check == false).Count();
            ViewBag.dgr4 = variable4;

            var variable5 = db.Tbl_Category.Count();
            ViewBag.dgr5 = variable5;

            var variable8 = db.MaxHaveBookAuthor().FirstOrDefault();
            ViewBag.dgr8 = variable8;
            
            var variable9 = db.Tbl_Book.GroupBy(x=>x.Publisher).OrderByDescending(z=>z.Count()).Select(y=> y.Key).FirstOrDefault();
            ViewBag.dgr9 = variable9;


            var variable11 = db.Tbl_Contect.Count();
            ViewBag.dgr11 = variable11;



            return View();
        }
        
    }
}