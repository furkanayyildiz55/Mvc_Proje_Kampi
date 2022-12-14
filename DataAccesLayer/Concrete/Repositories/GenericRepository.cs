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

    //ANA İŞİ YAPAN EF KODLARI BULUNMAKTA
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
            var deletedEnitiy = c.Entry(p);
            deletedEnitiy.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //Dizde veya listede sadece bir değer döndürek için kullanılan EF linq methodu
        }



        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State= EntityState.Added;   
            //_object.Add(p);
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
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        //ÖZEL OLARAK SÜTUN SAYISI ÇEKMEK İÇİN
        public int SpesificCoulmnCount(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).Count();
        }

        ///TOPLAM SÜTUN SAYISINI VERİR
        public int CoulmCount()
        {
            return _object.Count();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _object.FirstOrDefault(filter);
            
        }






    }
}
