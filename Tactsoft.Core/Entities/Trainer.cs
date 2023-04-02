using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Trainer:BaseEntity
    {
        [Display(Name = "Trainer Name")]
        public string TrainerName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Joining Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Last Academic Info")]
        public string LastAcademicInfo { get; set; }
        public string Experience { get; set; }
        public string Expertise { get; set; }
        public string AboutTrainer { get; set; }
        public string Picture { get; set; }
        public string CV { get; set; }

        public IList<Batch> Batchs { get; set; }

    }
}
