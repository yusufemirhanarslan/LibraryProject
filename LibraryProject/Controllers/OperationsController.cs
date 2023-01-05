using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models.Entity;
namespace LibraryProject.Controllers
{
    public class OperationsController : Controller
    {
        // GET: Operations
        DB_LibraryEntities db = new DB_LibraryEntities();
        public ActionResult Index()
        {
            var variables = db.Tbl_Action.Where(x => x.Action_State == true).ToList();
            return View(variables);
        }
    }
}