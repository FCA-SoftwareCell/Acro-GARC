﻿using System.ComponentModel.DataAnnotations;

namespace AcroGARC.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(126)]
        public string Name { get; set; }

        [Required]
        public int ClassStructureId { get; set; }

        public ClassStructure ClassStructure { get; set; }
    }
}