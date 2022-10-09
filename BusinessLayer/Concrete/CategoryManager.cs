using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //_categoryDal nesnesi ile IRepository içindeki methodları çekebiliyorum 
        //buda bizi GenericRepository e olan bağımlılıktan kurtarıyor.
        // bu işleme Dependency Injection denir.

        //Başka bir gün GenericRepository değiştiği zaman sadece değişen sınıfa interface eklemek  benim için yeterli olacaktır

        ICategoryDal _categoryDal;

        public CategoryManager (ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            throw new NotImplementedException();
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }


        #region
        // GenericRepository<Category> repo = new GenericRepository<Category>();
        /*
         public List<Category> GetAllBL()
         {
             return repo.List();
         }

         public void CategoryAddBL(Category p)
         {

             if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" ||
                 p.CategoryStatus == false || p.CategoryName.Length >= 50)
             {
                 //hata mesajı
             }
             else
             {
                 repo.Insert(p);
             }
         }
        */
        #endregion

    }
}
