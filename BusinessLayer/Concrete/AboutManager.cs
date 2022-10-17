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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal _AboutDal)
        {
            _aboutDal = _AboutDal;
        }

        public void AboutAdd(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public About GetById(int id)
        {
            var aboutValue = _aboutDal.Get(x =>x.AboutID == id);
            return aboutValue;
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }
}
