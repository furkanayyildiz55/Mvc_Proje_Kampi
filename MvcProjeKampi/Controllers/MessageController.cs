using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator messageValidations = new MessageValidator();  

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

        public ActionResult DeletedBox()
        {
            var deletedMessageList = messageManager.GetListDeletedbox();
            return View(deletedMessageList);
        }

        public ActionResult DraftedBox()
        {
            var draftedMessageList = messageManager.GetListDraftedbox();
            return View(draftedMessageList);
        }



        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message , string submit)
        {
            if(submit == "active")
            {
                message.MessageStatus = "active";
            }
            
            if(submit == "draft")
            {
                message.MessageStatus = "draft";
            }



            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ValidationResult results = messageValidations.Validate(message);
            if(results.IsValid)
            {
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var MessageValues = messageManager.GetById(id);
            return View(MessageValues);
        }


        public ActionResult SenBoxMessageDetails(int id)
        {
            var MessageValues = messageManager.GetById(id);
            return View(MessageValues);
        }
    }
}