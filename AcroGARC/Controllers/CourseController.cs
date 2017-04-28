using AcroGARC.Models;
using AcroGARC.ViewModels;
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


        public ActionResult Create()
        {
            var department = _context.Departments.ToList();

            var viewModel = new CourseViewModel
            {
                Departments = department,
                Heading = "New Course"
            };

            return View("CourseForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                courseModel.Departments = _context.Departments.ToList();

                return View("CourseForm", courseModel);
            }

            var course = new Courses
            {
                Name = courseModel.Name,
                DepartmentId = courseModel.DepartmentId,
                Duration = courseModel.Duration,

            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToAction("Index", "Course");
        }


        public ActionResult Edit(int courseId)
        {
            var dept = _context.Departments.ToList();

            var course = _context.Courses.Include(c => c.Department).SingleOrDefault(c => c.Id == courseId);

            if (course == null)
                return HttpNotFound();

            var viewModel = new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                DepartmentId = course.DepartmentId,
                Duration = course.Duration,
                Heading = "Edit Course",
                Departments = dept
            };

            return View("CourseForm", viewModel);
        }

        public ActionResult Update(CourseViewModel ViewModel)
        {
            return View();
        }

        //public ActionResult GetCourseClasses(int courseId)
        //{
        //    var semesters = _context.CourseSemesterMap.Include(s => s.Semester).Where(c => c.CourseId == courseId).ToList();
        //    var course = _context.Courses.SingleOrDefault(c => c.Id == courseId);

        //    var viewModel = new CourseSemesterViewModel
        //    {
        //        CourseSemesterList = semesters,
        //        CourseName = course.Name
        //    };

        //    return View(viewModel);
        //}

        public ActionResult GetCourseClasses(int courseId)
        {
            var classData = _context.ClassStucture.Include(s => s.Semester).Where(a => a.CourseId == courseId).ToList();

            return View(classData);
        }



    }
}