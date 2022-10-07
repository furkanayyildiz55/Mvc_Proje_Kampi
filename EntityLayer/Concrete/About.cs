using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]   //Bu işaretlerer Attibute denir ve veritabanında oluşturulacak tablolarda sınırlandırma işine yarar
        public int AboutID { get; set; }

        [StringLength(1000)]
        public String AboutDetails1 { get; set; }

        [StringLength(1000)]
        public String AboutDetails2 { get; set; }

        [StringLength(100)]
        public String AboutImage1 { get; set; }

        [StringLength(100)]
        public String AboutImage2{ get; set; }

    }
}
