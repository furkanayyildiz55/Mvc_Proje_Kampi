using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
        //EntityLayerdaki clasları kullandığımız için bu katmana refarans yöntemi ile EntityLayer ı ekliyoruz
        //REferances > add referances > Projects > Eklemek istediğimiz katman 

        //Property isimlerinin "s"takısı almasını sebebi sınıf isimleri ile karışmaması
        //"s" takısı olan isimler veritabanında tablo isimi olacaklar

        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public  DbSet<Contact> Contacts { get; set; }
        public  DbSet<Content> Contents { get; set; }
        public DbSet<Heading>    Headings{ get; set; }
        public DbSet<Writer> Writers{ get; set; }




    }
}
