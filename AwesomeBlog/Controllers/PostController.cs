using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AwesomeBlog.Models;

namespace AwesomeBlog.Controllers
{
    public class PostController : Controller
    {
        private My_BlogEntities db = new My_BlogEntities();

        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View(db.blogstuufs.ToList());
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id = 0)
        {
            blogstuuf blogstuuf = db.blogstuufs.Find(id);
            if (blogstuuf == null)
            {
                return HttpNotFound();
            }
            return View(blogstuuf);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(blogstuuf blogstuuf)
        {
            if (ModelState.IsValid)
            {
                db.blogstuufs.Add(blogstuuf);
                db.SaveChanges();
                return RedirectToAction("Posts");
            }

            return View(blogstuuf);
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id = 0)
        {
            blogstuuf blogstuuf = db.blogstuufs.Find(id);
            if (blogstuuf == null)
            {
                return HttpNotFound();
            }
            return View(blogstuuf);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(blogstuuf blogstuuf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogstuuf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Post");
            }
            return View(blogstuuf);
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id = 0)
        {
            blogstuuf blogstuuf = db.blogstuufs.Find(id);
            if (blogstuuf == null)
            {
                return HttpNotFound();
            }
            return View(blogstuuf);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blogstuuf blogstuuf = db.blogstuufs.Find(id);
            db.blogstuufs.Remove(blogstuuf);
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