using AcroGARC.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
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


            if (User.IsInRole("Faculty"))
            {
                var userID = User.Identity.GetUserId();

                var subjects = _context.SubjectAllocation.Include(i => i.Subject).Include(u => u.Faculty)
                                .Where(u => u.Faculty.Id == userID).Select(a => a.Subject).ToList();

                return View("Faculty", subjects);
            }
            return View();
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