using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Index()
        {
            var variables = db.Tbl_Staff.ToList();
            return View(variables);
        }

        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Tbl_Staff p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddStaff");
            }
            db.Tbl_Staff.Add(p);
            db.SaveChanges();
            return View();

        }

        public ActionResult StaffDelete(int id)
        {
            var staff = db.Tbl_Staff.Find(id);
            db.Tbl_Staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CallStaff(int id)
        {
            var staff1 = db.Tbl_Staff.Find(id);
            return View("CallStaff", staff1);
        }

        public ActionResult Updatestaff(Tbl_Staff p)
        {
            var st = db.Tbl_Staff.Find(p.ID);
            st.Staff = p.Staff;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}