namespace AcroGARC.Models
{
    public class ClassStructure
    {
        public int Id { get; set; }

        public Courses Course { get; set; }

        public int CourseId { get; set; }

        public Semester Semester { get; set; }

        public int SemesterId { get; set; }

    }
}