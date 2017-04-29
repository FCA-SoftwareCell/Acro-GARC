using AcroGARC.Models;
using AcroGARC.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AcroGARC.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext _context;

        public SubjectController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Subject
        public ActionResult Index(int Id)
        {
            ViewBag.id = Id;
            var list = _context.SubjectAllocation.Include(a => a.Faculty).Include(a => a.Subject).Where(c => c.Subject.ClassStructureId == Id);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add(int Id)
        {
            var faculties = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "7b224a17-17e4-4611-88a9-13004bbda20e"));


            var subjs = _context.Subjects.Where(s => s.ClassStructureId == Id);

            var viewModel = new SubjectAllocationViewModel
            {
                Faculties = faculties,
                Subjects = subjs,
                ClassStructureId = Id
            };

            return View("SubjectForm", viewModel);
        }

        [HttpPost]
        public ActionResult Add(SubjectAllocationViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                int Id = vm.ClassStructureId;
                vm.Faculties = _context.Users.Where(u => u.Roles.Any(r => r.RoleId == "7b224a17-17e4-4611-88a9-13004bbda20e"));
                vm.Subjects = _context.Subjects.Where(s => s.ClassStructureId == Id);
                return View("SubjectForm", vm);
            }
            var obj = new SubjectAllocation
            {
                FacultyId = vm.FacultyId,
                SubjectId = vm.SubjectId
            };

            _context.SubjectAllocation.Add(obj);
            _context.SaveChanges();

            return RedirectToAction("Index", "Subject", new { id = vm.ClassStructureId });
        }
    }
}