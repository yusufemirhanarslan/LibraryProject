using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Index()
        {
            var variables = db.Tbl_Category.Where(x=>x.State == true).ToList();
            return View(variables);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            //sayfayı yükleyince
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Tbl_Category p)
        {
             // sayfa üzerinde post işlemi yapılınca
             db.Tbl_Category.Add(p);
             db.SaveChanges();
             return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            var category = db.Tbl_Category.Find(id);
            //db.Tbl_Category.Remove(category);
            category.State = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult CallCategory(int id)
        {
            var category1 = db.Tbl_Category.Find(id);
            return View("CallCategory",category1);
        }

        public ActionResult UpdateCategory(Tbl_Category p)
        {
            var ct = db.Tbl_Category.Find(p.ID);
            ct.Name = p.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}