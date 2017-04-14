using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcroGARC.Models
{
    public class BatchRecord
    {
        public ClassStructure classStructure { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ClassStructureId { get; set; }

        public Batch Batch { get; set; }


        [Key]
        [Column(Order = 2)]
        public int BatchId { get; set; }
    }
}