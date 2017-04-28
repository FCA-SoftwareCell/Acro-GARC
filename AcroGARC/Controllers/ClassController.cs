using System.Web.Mvc;

namespace AcroGARC.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View("Dashboard");
        }
    }
}