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
    public class UsersController : Controller
    {
        private studentmanager_csharpEntities db = new studentmanager_csharpEntities();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            var users = db.users.Include(u => u.profile);
            return View(users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.profiles, "Id", "NameProfile");
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.profiles, "Id", "NameProfile", user.ProfileId);
            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.profiles, "Id", "NameProfile", user.ProfileId);
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileId = new SelectList(db.profiles, "Id", "NameProfile", user.ProfileId);
            return View(user);
        }

        
        public ActionResult Login(user user)
        {
            var connect = from p in db.profiles
                          join u in db.users on p.Id equals u.ProfileId
                          where (u.UserName == user.UserName && u.pwd == user.pwd)
                          select new
                          {
                              profile_name = p.NameProfile,
                              user_name = user.FirstName,
                          };
            var one = connect.FirstOrDefault(); //one result

            if (one != null)
            {
                Session["loggedUser"] = one.user_name.ToString();
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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