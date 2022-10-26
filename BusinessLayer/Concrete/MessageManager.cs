using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com" && x.MessageStatus == "active");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.MessageStatus == "active");
        }

        public List<Message> GetListDeletedbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.MessageStatus=="delete");
        }

        public List<Message> GetListDraftedbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.MessageStatus == "draft");

        }


        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }


        public int InboxMessageCount(string User)
        {
            return _messageDal.SpesificCoulmnCount(x => x.ReceiverMail == User);
            MessageStatus.aktive.ToString();
        }


    }

    enum MessageStatus
    {
        aktive , deleted , draft
    }
}
