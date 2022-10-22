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
    public class MessageController : Controller
    {
        //İletişim kısmı web sitesine gönderilen mesajlar 
        //Gelen ve Gönderilen mesajlar ise site özel içi mesajlasmalar 


        MessageManager messageManager = new MessageManager(new EfMessageDal());

        // GET: Message
        public ActionResult Inbox()
        {
            var ınboxmessageList = messageManager.GetListInbox();
            return View(ınboxmessageList);
        }

        public ActionResult Sendbox()
        {
            var sendMessageList = messageManager.GetListSendbox();
            return View(sendMessageList);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            return View();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var MessageValues = messageManager.GetById(id);
            return View(MessageValues);
        }

    }
}