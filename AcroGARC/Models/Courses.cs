using System.ComponentModel.DataAnnotations;

namespace AcroGARC.Models
{
    public class Courses
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public Department Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}