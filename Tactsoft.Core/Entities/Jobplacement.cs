using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Jobplacement : BaseEntity
    {
        public string Designation { get; set; }
        [Required]
        [Display(Name = "Date Of Joining")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateOfJoining { get; set; } = DateTime.Now;
        [Required]
        public float Salary { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public long DepartmentId { get; set; }

        [ForeignKey("Organization")]
        [Display(Name = "Organization Name")]
        public long OrganizationId { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Student Name")]
        public long StudentId { get; set; }
        public string Remarks { get; set; }
        public Department Department { get; set; }
        public Organization Organization { get; set; }
        public Student Student { get; set; }


    }
}
