using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPS.BLL;
using BPS.Models;
using Microsoft.Ajax.Utilities;

namespace BPS.Controllers
{
	public class EngineerController : Controller
	{
		//
		// GET: /Engineer/
		[HttpGet]
		public ActionResult SaveEngInfo()
		{
			return View();
		}
        EngineerBLL AEngineerBll = new EngineerBLL();
		[HttpPost]
		public ActionResult SaveEngInfo(Engineer aEngineer)
		{
			
			ViewBag.Message = AEngineerBll.SaveEngProfile(aEngineer);
			return View();
		}

		public ActionResult EngineerViewProfile()
		{
		    List<Engineer> EngineerProfile = AEngineerBll.EngineersViewProfile();
            return View(EngineerProfile);
		}
	}
}