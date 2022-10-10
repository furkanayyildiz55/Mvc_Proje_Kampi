using BusinessLayer.Concrete;
using BusinessLayer.FloentValidation;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

        CategoryManager cm = new CategoryManager(new EfCategoryDal());


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
             var categoryvalues = cm.GetList(); //kategory tablomuzdaki veriler gelecek
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
            // cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList"); //eklemeden sonre beni GetCategoryList methoduna yönlendir demek
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();  
        }
    }
}