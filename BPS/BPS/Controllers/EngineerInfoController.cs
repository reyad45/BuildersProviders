using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BPS.Models;
using BPS.BLL;

namespace BPS.Controllers
{
    public class EngineerInfoController : Controller
    {
        public EngineersEntities db = new EngineersEntities();

        // GET: /EngineerInfo/
        public ActionResult Index()
        {
            return View(db.Engineers.ToList());
        }

        // GET: /EngineerInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            if (engineer == null)
            {
                return HttpNotFound();
            }
            return View(engineer);
        }

        //Get Hire Request
        public ActionResult Hire(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            HireEng hire = new HireEng();
            hire.Eid = engineer.id;
            hire.Sid = Convert.ToInt32( Session["UserID"]);
            hire.EngineerName = engineer.engName;
            hire.engineerAddress=engineer.engAdress;
            if(engineer ==null)
            {
                return HttpNotFound();
            }
            return View(hire);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hire(HireEng aHireEng)
        {
            Engineer engineer = db.Engineers.Find(aHireEng.Id);
            aHireEng.Eid = engineer.id;
            aHireEng.Sid = Convert.ToInt32(Session["userID"]);
            aHireEng.EngineerName = engineer.engName;
            aHireEng.engineerAddress = engineer.engAdress;

            if(aHireEng.RequestText==null)
            {
                ViewBag.error = "Request Text doest not Empty!!!";
                return View(aHireEng);
            }

            if(ModelState.IsValid)
            {
                

                HireBLL aHire= new HireBLL();
                ViewBag.message = aHire.RequestHire(aHireEng);
                return View(aHireEng);
            }
     
           return RedirectToAction("Index");

        }

        // GET: /EngineerInfo/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult SaveEngInfo()
        {
            return View();
        }
        // POST: /EngineerInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEngInfo(Engineer aEngineer)
        {
            if (ModelState.IsValid)
            {
                bool isExist = db.Engineers.Any(x => x.engEmail == aEngineer.engEmail);

                if (isExist == true)
                {
                    ModelState.AddModelError("engEmail", "Already Exist");
                    return View(aEngineer);
                }
                EngineerBLL AEngineerBll = new EngineerBLL();

                ViewBag.Message = AEngineerBll.SaveEngProfile(aEngineer);
                return RedirectToAction("Index");

            }
            else
                return View(aEngineer);
            
       

            //return View(aEngineer);
        }

        // GET: /EngineerInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            if (engineer == null)
            {
                return HttpNotFound();
            }
            return View(engineer);
        }

        // POST: /EngineerInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,engName,engEmail,engContact,engAbout,engAdress,engCountry,engDetails")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engineer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engineer);
        }

        // GET: /EngineerInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engineer engineer = db.Engineers.Find(id);
            if (engineer == null)
            {
                return HttpNotFound();
            }
            return View(engineer);
        }

        // POST: /EngineerInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engineer engineer = db.Engineers.Find(id);
            db.Engineers.Remove(engineer);
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
