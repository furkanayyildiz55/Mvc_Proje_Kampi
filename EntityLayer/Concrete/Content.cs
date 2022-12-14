using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //içerik
    public class Content
    {

        [Key]
        public int ContentID { get; set; }
        
        [StringLength(1000)]
        public string ContentValue { get; set; }
        
        public DateTime ContentDate { get; set; }

        //Her yazının bir heading i olmalı 
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public bool ContentStatus { get; set; }

        //Her yazını bir yazarı olmalı
        //? değerin veritabanında boş geçilmesine izin verirr
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
        

    }
}
