using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {

        // GET: Category //Busiennes Layer den geliyor ve veritabanı kontrollerini gerçekleştirip vt işlemi yapıyor
        CategoryManager cm = new CategoryManager();
        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetAllBL(); //kategory tablomuzdaki veriler gelecek
            return View(categoryvalues); //View dönerken içerisine categoryvalues değerleri aktarılacak

        }

        //HttpGet ve Post Attributelerini kullanıyoruz
        //sayfa yüklendiği zaman httpGet attribute devreye  girecek
        //sayfada butona tıklandığında httpPost devreye girecek


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]   //Sayfada butona tıklandığı zaman çalışacak
        public ActionResult AddCategory(Category p) //wiev in geriye döndüreceği parametre
        {
            cm.CategoryAddBL(p);    
            return RedirectToAction("GetCategoryList");  //eklemeden sonre beni GetCategoryList methoduna yönlendir demek
        }
    }
}