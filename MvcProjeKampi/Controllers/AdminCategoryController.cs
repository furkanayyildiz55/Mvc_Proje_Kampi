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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddCategory( Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result= categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction( "Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        public ActionResult DeleteKategory (int id)
        {
            var categoryValue = cm.GetById(id);
            cm.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }
    }
}