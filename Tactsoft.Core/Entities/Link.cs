using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Link : BaseEntity
    {
        public string LinkUrl { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime ClassDate { get; set; }= DateTime.Now;
        [Required]
        [ForeignKey("Batch")]
        [Display(Name = "Batch")]
        public long BatchId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Display(Name = "Course Name")]
        public long CourseId { get; set; }
        public Batch Batch { get; set; }
        public Course Course { get; set; }

    }
}
