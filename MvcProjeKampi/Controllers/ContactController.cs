using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContatcManager contatcManager = new ContatcManager(new EfContactDal() );
        ContactValidator contactValidator = new ContactValidator();

        int DenemeDeğşken;

        // GET: Contact
        public ActionResult Index()
        {
            var ContactValues = contatcManager.GetList();
            return View(ContactValues);
        }
    }
}