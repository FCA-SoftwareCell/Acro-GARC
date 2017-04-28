using AcroGARC.Models;
using AcroGARC.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcroGARC.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: Student
        public ActionResult Index(int id)
        {
            var Students = _context.ClassOrganisation.Where(a => a.ClassStructure.Id == id).Select(a => a.Student);

            if (Students == null)
            {
                ViewBag.ClassStructureId = id;
                return View("NoStudentFound");
            }

            var viewModel = new StudentViewModel
            {
                Students = Students,
                classStructureId = id

            };


            return View("ClassStudents", viewModel);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            var viewModel = new StudentAddForm { classStructureId = id };
            return View("StudentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentAddForm viewModel)
        {
            string UserName = viewModel.UserName;
            string RoleName = "Student";

            int id = viewModel.classStructureId;

            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            UserManager.AddToRole(user.Id, RoleName);

            var student = new ClassOrganisation
            {

                ClassStructureId = viewModel.classStructureId,
                StudentId = user.Id,

            };

            _context.ClassOrganisation.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }


    }
}