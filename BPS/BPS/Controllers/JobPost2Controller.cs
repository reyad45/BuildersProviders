using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BPS.Models;

namespace BPS.Controllers
{
    public class JobPost2Controller : Controller
    {
        private BuildersEntities db = new BuildersEntities();

        // GET: /JobPost2/
        public ActionResult Index()
        {
            var job_post = db.Job_Post.Include(j => j.BuildingType).Include(j => j.Location1).Include(j => j.ServiceType);
            return View(job_post.ToList());
        }

        // GET: /JobPost2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Post job_post = db.Job_Post.Find(id);
            if (job_post == null)
            {
                return HttpNotFound();
            }
            return View(job_post);
        }

        // GET: /JobPost2/Create
        public ActionResult Create()
        {
            ViewBag.build_id = new SelectList(db.BuildingTypes, "id", "Type");
            ViewBag.LocID = new SelectList(db.Locations, "id", "Location1");
            ViewBag.Ser_id = new SelectList(db.ServiceTypes, "id", "SerType");
            return View();
        }

        // POST: /JobPost2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,build_id,Ser_id,Land_Size,Description,Location,Price,LocID,ClientID,Address,Building_Name,LocationName")] Job_Post job_post)
        {
            if (ModelState.IsValid)
            {
                db.Job_Post.Add(job_post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.build_id = new SelectList(db.BuildingTypes, "id", "Type", job_post.build_id);
            ViewBag.LocID = new SelectList(db.Locations, "id", "Location1", job_post.LocID);
            ViewBag.Ser_id = new SelectList(db.ServiceTypes, "id", "SerType", job_post.Ser_id);
            return View(job_post);
        }

        // GET: /JobPost2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Post job_post = db.Job_Post.Find(id);
            if (job_post == null)
            {
                return HttpNotFound();
            }
            ViewBag.build_id = new SelectList(db.BuildingTypes, "id", "Type", job_post.build_id);
            ViewBag.LocID = new SelectList(db.Locations, "id", "Location1", job_post.LocID);
            ViewBag.Ser_id = new SelectList(db.ServiceTypes, "id", "SerType", job_post.Ser_id);
            return View(job_post);
        }

        // POST: /JobPost2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,build_id,Ser_id,Land_Size,Description,Location,Price,LocID,ClientID,Address,Building_Name,LocationName")] Job_Post job_post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job_post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.build_id = new SelectList(db.BuildingTypes, "id", "Type", job_post.build_id);
            ViewBag.LocID = new SelectList(db.Locations, "id", "Location1", job_post.LocID);
            ViewBag.Ser_id = new SelectList(db.ServiceTypes, "id", "SerType", job_post.Ser_id);
            return View(job_post);
        }

        // GET: /JobPost2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Post job_post = db.Job_Post.Find(id);
            if (job_post == null)
            {
                return HttpNotFound();
            }
            return View(job_post);
        }

        // POST: /JobPost2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job_Post job_post = db.Job_Post.Find(id);
            db.Job_Post.Remove(job_post);
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
