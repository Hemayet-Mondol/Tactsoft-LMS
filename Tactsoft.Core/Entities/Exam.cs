using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Exam:BaseEntity
    {
        [Required]
        [Display(Name ="Exam Name")]
        public string ExamName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime EndDate { get; set; }

        public IList<ExamResult> ExamResults { get; set; }

    }
}
