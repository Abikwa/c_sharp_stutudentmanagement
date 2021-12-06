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
    public class LessonsController : Controller
    {
        private studentmanager_csharpEntities db = new studentmanager_csharpEntities();

        //
        // GET: /Lessons/

        public ActionResult Index()
        {
            var lessons = db.lessons.Include(l => l.responsible);
            return View(lessons.ToList());
        }

        public JsonResult getresponsibles(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<lesson> lessons = db.lessons.Where(item => item.ResponsibleId == id).ToList();
            return Json(lessons, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Lessons/Details/5

        public ActionResult Details(int id = 0)
        {
            lesson lesson = db.lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        //
        // GET: /Lessons/Create

        public ActionResult Create()
        {
            ViewBag.ResponsibleId = new SelectList(db.responsibles, "Id", "NameResponsible");
            return View();
        }

        //
        // POST: /Lessons/Create

        [HttpPost]
        public ActionResult Create(lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsibleId = new SelectList(db.responsibles, "Id", "NameResponsible", lesson.ResponsibleId);
            return View(lesson);
        }

        //
        // GET: /Lessons/Edit/5

        public ActionResult Edit(int id = 0)
        {
            lesson lesson = db.lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsibleId = new SelectList(db.responsibles, "Id", "NameResponsible", lesson.ResponsibleId);
            return View(lesson);
        }

        //
        // POST: /Lessons/Edit/5

        [HttpPost]
        public ActionResult Edit(lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsibleId = new SelectList(db.responsibles, "Id", "NameResponsible", lesson.ResponsibleId);
            return View(lesson);
        }

        //
        // GET: /Lessons/Delete/5

        public ActionResult Delete(int id = 0)
        {
            lesson lesson = db.lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        //
        // POST: /Lessons/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            lesson lesson = db.lessons.Find(id);
            db.lessons.Remove(lesson);
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