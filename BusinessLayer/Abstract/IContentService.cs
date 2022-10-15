using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService 
    {
        List<Content> GetList();
        List<Content> GetListByHeadingID(int id);

        void HeadingAdd(Content content);
        void HeadingDelete(Content content);
        void HeadingUpdate(Content content);

        Content GetByID(int id);
    }
}
