using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DEMOMVC.Models;

namespace DEMOMVC.Controllers
{
    public class PersonController : Controller
    {
        LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();
        // GET: Person
        public ActionResult Index()
        {
            var model = db.Persons.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        

    }
}