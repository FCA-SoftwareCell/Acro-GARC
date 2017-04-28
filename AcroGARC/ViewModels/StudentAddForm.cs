using System.ComponentModel.DataAnnotations;

namespace AcroGARC.ViewModels
{
    public class StudentAddForm
    {
        [Display(Name = "Email")]
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }


        public int classStructureId { get; set; }





    }
}