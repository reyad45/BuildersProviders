using BPS.BLL;
using BPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPS.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        SupplierBLL aSupplierBLL = new SupplierBLL();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Supplier aSuppler)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = aSupplierBLL.SaveSupProfile(aSuppler);

                return View();
            }
            else
                return View(aSuppler);
        }

	}
}