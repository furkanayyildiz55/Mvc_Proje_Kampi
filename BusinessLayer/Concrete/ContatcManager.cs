using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContatcManager : IContactService
    {
        IContactDal _contactDal;

        public ContatcManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            var contactValue = _contactDal.Get(x => x.ContactID == id);
            return contactValue;
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }


    }
}
