using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DB_LibraryEntities db = new DB_LibraryEntities(); 
        public ActionResult Index(string p)
        {
            var books = from book in db.Tbl_Book select book;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(b => b.Name.Contains(p));
            }
            //var books = db.Tbl_Book.ToList();
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> variable1 = (from i in db.Tbl_Category.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name,
                                                  Value = i.ID.ToString()
                                              }
                                              ).ToList();
            ViewBag.vrb1 = variable1;

            List<SelectListItem> variable2 = (from i in db.Tbl_Author.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name + ' '+ i.Surname,
                                                  Value = i.ID.ToString()
                                              }).ToList();
            ViewBag.vrb2 = variable2;   
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Tbl_Book p)
        {
            var category = db.Tbl_Category.Where(c=>c.ID == p.Tbl_Category.ID).FirstOrDefault();
            var author = db.Tbl_Author.Where(a => a.ID == p.Tbl_Author.ID).FirstOrDefault();
            p.Tbl_Category = category;
            p.Tbl_Author = author;
            db.Tbl_Book.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");   
         
        }

        public ActionResult DeleteBook(int id)
        {
            var book = db.Tbl_Book.Find(id);
            db.Tbl_Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CallBook(int id)
        {
            var book = db.Tbl_Book.Find(id);
            List<SelectListItem> variable1 = (from i in db.Tbl_Category.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name,
                                                  Value = i.ID.ToString()
                                              }
                                              ).ToList();
            ViewBag.vrb1 = variable1;

            List<SelectListItem> variable2 = (from i in db.Tbl_Author.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name + ' ' + i.Surname,
                                                  Value = i.ID.ToString()
                                              }).ToList();
            ViewBag.vrb2 = variable2;
            return View("CallBook",book);
        }

        public ActionResult BookUpdate(Tbl_Book p)
        {
            var book = db.Tbl_Book.Find(p.ID);
            book.Name = p.Name;
            book.Publisher = p.Publisher;
            book.Page = p.Page;
            book.Production_Year = p.Production_Year;
            book.Check = true;
            var category = db.Tbl_Category.Where(c => c.ID == p.Tbl_Category.ID).FirstOrDefault();
            var author = db.Tbl_Author.Where(c => c.ID == p.Tbl_Author.ID).FirstOrDefault();
            book.Category = category.ID;
            book.Author = author.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}