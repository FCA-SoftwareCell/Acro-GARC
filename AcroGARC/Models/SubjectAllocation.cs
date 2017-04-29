using System.ComponentModel.DataAnnotations;

namespace AcroGARC.Models
{
    public class SubjectAllocation
    {
        public int id { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }


        public string FacultyId { get; set; }

        public ApplicationUser Faculty { get; set; }
    }
}