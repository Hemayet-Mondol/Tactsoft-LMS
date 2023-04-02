using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class ExamResult:BaseEntity
    {
        [ForeignKey("Exam")]
        [Display(Name ="Exam Name")]
        public long ExamId { get; set; }
        [ForeignKey("Student")]
        [Display(Name = "Student Name")]
        public long StudentId { get; set; }
        public string Remarks { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }

        
    }
}
