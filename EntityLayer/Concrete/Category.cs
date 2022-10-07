using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Ana başlıkların bulunduğu sunıfımız
    //Bu sınıf heading sınıfı ile ilişki içirisinde olcadak ve heading buradan değer alacak 
    //Kategorinin birden fazla headingi olabilecek
    //Yani Her heading in bir kategorisi olacak 
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryDescription { get; set; }

        public bool CategoryStatus { get; set; }  //kategorinin kullanılıp kullanılamayacağını belirler

        public ICollection<Heading> Headings { get; set; }

    }

}
