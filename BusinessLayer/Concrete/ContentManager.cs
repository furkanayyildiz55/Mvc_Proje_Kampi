using BusinessLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {

        EfContentDal _ContentDal;

        public ContentManager(EfContentDal contentDal)
        {
            _ContentDal = contentDal;   
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _ContentDal.List(x=> x.HeadingID ==id);  //headingID si fonksiyona gelen id ile eşit olanların listesi gelecek
        }

        public void HeadingAdd(Content content)
        {
            throw new NotImplementedException();
        }

        public void HeadingDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void HeadingUpdate(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
