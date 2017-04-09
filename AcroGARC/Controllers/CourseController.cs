using AcroGARC.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AcroGARC.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext _context;

        public CourseController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Course
        public ActionResult Index()
        {
            var users = User.Identity.Name;

            var Courses = _context.Courses.Include(d => d.Department).ToList();

            return View(Courses);
        }
    }
}