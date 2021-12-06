using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentmanager.Models;

namespace studentmanager.Controllers
{
    public class ResponsiblesController : Controller
    {
        private studentmanager_csharpEntities db = new studentmanager_csharpEntities();

        //
        // GET: /Responsibles/

        public ActionResult Index()
        {
            return View(db.responsibles.ToList());
        }


        //
        // GET: /Responsibles/Details/5

        public ActionResult Details(int id = 0)
        {
            responsible responsible = db.responsibles.Find(id);
            if (responsible == null)
            {
                return HttpNotFound();
            }
            return View(responsible);
        }

        //
        // GET: /Responsibles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Responsibles/Create

        [HttpPost]
        public ActionResult Create(responsible responsible)
        {
            if (ModelState.IsValid)
            {
                db.responsibles.Add(responsible);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsible);
        }

        //
        // GET: /Responsibles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            responsible responsible = db.responsibles.Find(id);
            if (responsible == null)
            {
                return HttpNotFound();
            }
            return View(responsible);
        }

        //
        // POST: /Responsibles/Edit/5

        [HttpPost]
        public ActionResult Edit(responsible responsible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsible);
        }

        //
        // GET: /Responsibles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            responsible responsible = db.responsibles.Find(id);
            if (responsible == null)
            {
                return HttpNotFound();
            }
            return View(responsible);
        }

        //
        // POST: /Responsibles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            responsible responsible = db.responsibles.Find(id);
            db.responsibles.Remove(responsible);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}