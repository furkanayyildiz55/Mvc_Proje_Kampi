using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ImageFileManager = new ImageFileManager(new EfImageFileDal());

        // GET: Gallery
        public ActionResult Index()
        {

            var ImageLıst = ImageFileManager.GetList();
            return View(ImageLıst);
        }
    }
}