using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Index()
        {
            var variables = db.Tbl_Author.ToList();
            return View(variables);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Tbl_Author p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAuthor");
            }
            db.Tbl_Author.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteAuthor(int id)
        {
            var author = db.Tbl_Author.Find(id);
            db.Tbl_Author.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AuthorCall(int id)
        {
            var author1 = db.Tbl_Author.Find(id);
            return View("AuthorCall", author1);
        }

        public ActionResult AuthorUpdate(Tbl_Author a)
        {
            var athr = db.Tbl_Author.Find(a.ID);
            athr.Name = a.Name;
            athr.Surname = a.Surname;
            athr.Detail = a.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AuthorBooks(int id)
        {
            var author = db.Tbl_Book.Where(x => x.Author == id).ToList();
            var authorName = db.Tbl_Author.Where(y => y.ID == id).Select(z => z.Name + " " + z.Surname).FirstOrDefault();
            ViewBag.author = authorName;
            return View(author);
        }
    }
}