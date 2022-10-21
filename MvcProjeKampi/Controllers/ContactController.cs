using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContatcManager contatcManager = new ContatcManager(new EfContactDal() );
        ContactValidator contactValidator = new ContactValidator();

        MessageManager messageManager = new MessageManager(new EfMessageDal());


        // GET: Contact
        public ActionResult Index()
        {
            var ContactValues = contatcManager.GetList();
            return View(ContactValues);
        }

        public ActionResult GetContactDetail(int id)
        {
            var contactValues = contatcManager.GetByID(id);
            return View(contactValues);  
        }

        public PartialViewResult MessageListMenu()
        {
            int ınboxMessageCount = messageManager.InboxMessageCount("admin@gmail.com");
            int MessageCount = contatcManager.CoulmnCount();

            int[] values =new int[] { MessageCount, ınboxMessageCount,  };

            return PartialView(values);
        }
    }
}