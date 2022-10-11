using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    //Veritabanında bulunan her tablo için veri işlemek amacıyla class yazılır.
    //Ve bu classlara methodlar interface den implemen edilir

    //IRepository interface bize yukarıdaki konu için genericlik sağlar, classlara referans olacak-
    //interfaceler için kendisi referans olarak kod tekrarının önüne geçer.

    //Generic yapı olduğundan Tip'ler T türünde belirtilir.T içine herhangi bit türü alabilen bir değerdir.
    public interface IRepository<T>  
    {
        List<T> List();
        void Insert(T p);
        void Delete(T p);
        void Update(T p);
        T Get(Expression<Func<T,bool>> filter);

        List<T>  List (Expression<Func<T, bool>> filter);
    }
}
