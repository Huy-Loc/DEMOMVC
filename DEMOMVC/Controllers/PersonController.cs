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
            var countModel = db.Persons.Count();
            ViewBag.soBanGhi = countModel;
            var model = db.Persons.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person std)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }


    }
}