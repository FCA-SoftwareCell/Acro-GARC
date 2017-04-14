using System.ComponentModel.DataAnnotations;

namespace AcroGARC.Models
{
    public class Semester
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}