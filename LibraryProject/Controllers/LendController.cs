using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    public class LendController : Controller
    {
        // GET: Borrow
        DB_LibraryEntities db = new DB_LibraryEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var variables = db.Tbl_Action.Where(x => x.Action_State == false).ToList();
            return View(variables);
        }


        [HttpGet]
        public ActionResult Lending()
        {
            //sayfayı yükleyince
            List<SelectListItem> variable1 = (from x in db.Tbl_Users.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name + " " + x.Surname,
                                                  Value = x.ID.ToString()
                                              }).ToList();

            List<SelectListItem> variable2 = (from y in db.Tbl_Book.Where(x=>x.Check==true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = y.Name,
                                                  Value = y.ID.ToString()   
                                              }).ToList();
            List<SelectListItem> variable3 = (from z in db.Tbl_Staff.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = z.Staff,
                                                  Value = z.ID.ToString()
                                              }).ToList();

            ViewBag.variable1 = variable1;
            ViewBag.variable2 = variable2;
            ViewBag.variable3 = variable3;
            return View();
        }
        [HttpPost]
        public ActionResult Lending(Tbl_Action p)
        {
            // sayfa üzerinde post işlemi yapılınca
            var vrb1 = db.Tbl_Users.Where(x=>x.ID== p.Tbl_Users.ID).FirstOrDefault();
            var vrb2 = db.Tbl_Book.Where(y=>y.ID== p.Tbl_Book.ID).FirstOrDefault();
            var vrb3 = db.Tbl_Staff.Where(z=>z.ID== p.Tbl_Staff.ID).FirstOrDefault();
            p.Tbl_Users = vrb1;
            p.Tbl_Book = vrb2;
            p.Tbl_Staff = vrb3;

            db.Tbl_Action.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ReturnBook(Tbl_Action p)
        {
            var returnBook = db.Tbl_Action.Find(p.ID);
            DateTime d1 = DateTime.Parse(returnBook.Return_Date.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("ReturnBook", returnBook);
        }

        public ActionResult UpdateReturn(Tbl_Action p)
        {
            var act = db.Tbl_Action.Find(p.ID);
            act.Delivery_Date = p.Delivery_Date;
            act.Action_State = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}