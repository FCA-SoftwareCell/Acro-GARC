using System.ComponentModel.DataAnnotations;

namespace AcroGARC.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


    }
}