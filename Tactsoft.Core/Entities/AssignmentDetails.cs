using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class AssignmentDetails : BaseEntity
    {
        public string AssignmentAttachment { get; set; }
        public float Marks { get; set; }
        [Required]
        [ForeignKey("Assignment")]
        [Display(Name = "Assignment Name")]
        public long AssignmentId { get; set; }
        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Student Name")]
        public long StudentId { get; set; }
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }

    }
}
