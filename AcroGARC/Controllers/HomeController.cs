using AcroGARC.Models;
using System.Linq;
using System.Web.Mvc;

namespace AcroGARC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var users = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "7b224a17-17e4-4611-88a9-13004bbda20e"));

            if (User.IsInRole("Faculty"))
                return View("Faculty");

            return View(users);
        }


        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}