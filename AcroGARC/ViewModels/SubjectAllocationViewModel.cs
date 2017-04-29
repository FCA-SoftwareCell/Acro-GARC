using AcroGARC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcroGARC.ViewModels
{
    public class SubjectAllocationViewModel
    {
        public int ClassStructureId { get; set; }

        [Display(Name = "Faculty")]
        public IEnumerable<ApplicationUser> Faculties { get; set; }

        [Required]
        public string FacultyId { get; set; }

        public ApplicationUser Faculty { get; set; }

        [Display(Name = "Subject")]
        public IEnumerable<Subject> Subjects { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}