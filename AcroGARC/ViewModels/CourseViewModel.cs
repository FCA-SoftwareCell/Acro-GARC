using AcroGARC.Controllers;
using AcroGARC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AcroGARC.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte Duration { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }


        public string Heading { get; set; }

        public string Action
        {

            get
            {
                Expression<System.Func<CourseController, ActionResult>> create = (c => c.Create(this));

                Expression<System.Func<CourseController, ActionResult>> update = (c => c.Update(this));

                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;
                return (actionName);
            }

        }
    }
}