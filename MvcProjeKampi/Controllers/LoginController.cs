using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal()); 

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index( Admin admin)
        {
            admin = adminManager.Login(admin);
            if (admin == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Inbox"  , "Message");
            }

            return View();
        }
    }
}