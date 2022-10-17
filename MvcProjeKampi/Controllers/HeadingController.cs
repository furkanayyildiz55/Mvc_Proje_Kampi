using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var HeadingList = hm.GetList();
            return View(HeadingList);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //DROPDOWN İÇİN 
            List<SelectListItem> valueCategory = (from x in cm.GetList()   //category listesi getirildi
                                                  select new SelectListItem  //selectListItem içinde değerleri atılıyor
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList(); //Bütün işlem listeye dönüştürülüyor
            ViewBag.category = valueCategory; // Controller'da oluşturulan bir yapıyı View kısmına taşımak için kullanılır.


            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.writer = valueWriter;



            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            //DROPDOWN İÇİN 
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.category = valueCategory;

            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = !HeadingValue.HeadingStatus;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }

    }
}