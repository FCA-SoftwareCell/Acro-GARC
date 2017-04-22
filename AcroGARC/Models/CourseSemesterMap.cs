using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcroGARC.Models
{
    public class CourseSemesterMap
    {
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SemesterId { get; set; }

        public Courses Course { get; set; }

        public Semester Semester { get; set; }

    }
}