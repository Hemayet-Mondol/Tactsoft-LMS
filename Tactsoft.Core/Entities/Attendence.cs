using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Attendence : BaseEntity
    {

        //public string Remarks { get; set; }
        //[Required]
        //[Display(Name = "Attendence Date")]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        //public DateTime AttendenceDate { get; set; }
        //[ForeignKey("Batch")]
        //[Required]
        //[Display(Name = "Batch")]
        //public long BatchId { get; set; }

        //public Batch Batch { get; set; }
        //public IList<AttendenceDetails> AttendenceDetailses { get; set; }

        [Required]
        [DisplayName("Attendence Date")]
        public DateTime AttendenceDate { get; set; }

        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public long StudentId { get; set; }

        [Required]
        [ForeignKey("Batch")]
        [Display(Name = "Batch Name")]
        public long BatchId { get; set; }

        [Required]
        [Display(Name = "Present Status")]
        public Boolean IsPresent { get; set; }
        public Student Student { get; set; }
        public Batch Batch { get; set; }

    }
}
