using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Assignment : BaseEntity
    {
        public string AssingmentName { get; set; }
        [Display(Name = "Assignment Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime AssingmentDate { get; set; }
        [Display(Name = "Assignment End Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime AssingmentEndDate { get; set; }
        public string AssingmentPdf { get; set; }
        public string Remarks { get; set; }
        [Required]
        [ForeignKey("Course")]
        [Display(Name = "Course Name")]
        public long CourseId { get; set; }
        [Required]
        [ForeignKey("Batch")]
        [Display(Name = "Batch")]
        public long BatchId { get; set; }

        public Batch Batch { get; set; }
        public Course Course { get; set; }
        public IList<AssignmentDetails> AssignmentDetails { get; set; }

    }
}
