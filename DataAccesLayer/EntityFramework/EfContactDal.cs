
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;


namespace DataAccesLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact> , IContactDal
    {
    
    }
}
