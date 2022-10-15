using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        Context context = new Context();///
        DbSet<Heading> _object;///

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }


        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public int GetSpecificHeading()
        {
            //  int veri = context.Headings.Count();
            //   int veri = context.Headings.GroupBy(x => x.WriterID).
            int veri = context.Headings.Where(x => x.CategoryID == 20).ToList().Count;
            return veri;
        }

    }
}
