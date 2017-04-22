using AcroGARC.Models;
using System.Collections.Generic;

namespace AcroGARC.ViewModels
{
    public class CourseSemesterViewModel
    {
        public IEnumerable<CourseSemesterMap> CourseSemesterList { get; set; }

        public string CourseName { get; set; }
    }
}