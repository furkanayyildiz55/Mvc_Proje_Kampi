using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());



        // GET: Statistics
        public ActionResult Index()
        {
            //int CategoryLength = cm.GetCategoryLength();
            int kategori = hm.GetSpecificHeading();
            return View(kategori);
        }
    }
}