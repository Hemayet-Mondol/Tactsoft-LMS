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
    public class AttendenceDetails:BaseEntity
    {
        public bool Present { get; set; }
        [Required]
        [ForeignKey("Attendence")]
        [Display(Name = "Attendence")]
        public long AttendenceId { get; set; }
        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Student Name")]
        public long StudentId { get; set; }

        public Attendence Attendence { get; set; }
        public Student Student { get; set; }
        


    }
}
