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
    public class BlogInfoesController : Controller
    {
        private BlogDbEntities db = new BlogDbEntities();
        private string Layout;

        // GET: BlogInfoes
        public ActionResult Index()
        {
            ViewBag.Layout = "~/Views/Shared/AdminLayout.cshtml";
            return View(db.BlogInfoes.ToList());
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var layout = filterContext.RouteData.Values["layout"];
            if (layout != null)
            {
                this.Layout = layout.ToString();
            }
            base.OnActionExecuting(filterContext);
        }
        // GET: BlogInfoes/Details/5
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

        // GET: BlogInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogInfoes/Create
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

        // GET: BlogInfoes/Edit/5
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

        // POST: BlogInfoes/Edit/5
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

        // GET: BlogInfoes/Delete/5
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

        // POST: BlogInfoes/Delete/5
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
