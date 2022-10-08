using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories
{
    //GenericRepository sınıfı IRepository<T> de bulunan methodları kullanır.
    //where T : class ifadesi T nin sadece class olabileceğini belirtir

    //context c = ile veri tabanı işlemelrimizi yapacağız (CRUD)
    //DbSet<T> _object = burada ise T yerine gelecek olan sınıf veritabanımızdaki tabloyu kontrol etmektedir
    //

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;  //objenin hangi classs olacağı belli değil

        public GenericRepository()
        {
            _object = c.Set<T>();  //c değeri yani Contextten gelen classı _object e aktar
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
