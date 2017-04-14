using AcroGARC.Models;
using System.Linq;
using System.Web.Mvc;

namespace AcroGARC.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext _context;

        public RoleController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        //GET Role/Create
        public ActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {

                    Name = collection["RoleName"]

                });

                _context.SaveChanges();

                ViewBag.ResultMessage = "Role Created Successfully";

                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }

        }

        public ActionResult Delete(string id)
        {
            var Role = _context.Roles.Single(r => r.Id == id);

            _context.Roles.Remove(Role);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Get
        public ActionResult Edit(string id)
        {
            var role = _context.Roles.SingleOrDefault(r => r.Id == id);

            if (role == null)
                return HttpNotFound();

            return View(role);
        }

        //Post
        [HttpPost]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}