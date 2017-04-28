using System.ComponentModel.DataAnnotations;

namespace AcroGARC.Models
{
    public class ClassOrganisation
    {
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        public ApplicationUser Student { get; set; }

        [Required]
        public int ClassStructureId { get; set; }

        public ClassStructure ClassStructure { get; set; }

    }
}