using AcroGARC.Models;
using System.Collections.Generic;

namespace AcroGARC.ViewModels
{
    public class StudentViewModel
    {
        public IEnumerable<ApplicationUser> Students { get; set; }

        public int classStructureId { get; set; }


    }
}