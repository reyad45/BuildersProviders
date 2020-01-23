using BPS.BLL;
using BPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPS.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        ClientBLL aClientBll = new ClientBLL();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }

        
        [HttpPost]
       
        public ActionResult Profile(ClientProfile aprofile)
        {
           
            ViewBag.Message = aClientBll.SaveProfile(aprofile);

            return View();
        }
        [HttpGet]
        public JsonResult IsEmailExist(string email)
        {
            List<ClientProfile> Clients = aClientBll.GetProfile();
            bool isExist = Clients.FirstOrDefault(u => u.Email.ToLowerInvariant().Equals(email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IsNumberExist(string phone)
        {
            List<ClientProfile> Clients = aClientBll.GetProfile();
            bool isExist = Clients.FirstOrDefault(u => u.Phone.ToLowerInvariant().Equals(phone.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
       
	}
}