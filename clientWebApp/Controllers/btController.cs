using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clientWebApp.Models;

namespace clientWebApp.Controllers
{
    public class btController : Controller
    {
        private BlogDbEntities db = new BlogDbEntities();

        // GET: bt
        public ActionResult Index()
        {
            return View(db.BlogInfoes.ToList());
        }

        // GET: bt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            if (blogInfo == null)
            {
                return HttpNotFound();
            }
            return View(blogInfo);
        }

        // GET: bt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Title,Subject,DateOfCreation,BlogUlrb,EmpEmailId")] BlogInfo blogInfo)
        {
            if (ModelState.IsValid)
            {
                db.BlogInfoes.Add(blogInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogInfo);
        }

        // GET: bt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            if (blogInfo == null)
            {
                return HttpNotFound();
            }
            return View(blogInfo);
        }

        // POST: bt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Title,Subject,DateOfCreation,BlogUlrb,EmpEmailId")] BlogInfo blogInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogInfo);
        }

        // GET: bt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            if (blogInfo == null)
            {
                return HttpNotFound();
            }
            return View(blogInfo);
        }

        // POST: bt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogInfo blogInfo = db.BlogInfoes.Find(id);
            db.BlogInfoes.Remove(blogInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
