using Tactsoft.Core;
using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tactsoft.Core.Defaults;

namespace Tactsoft.Core.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        [Display(Name = "Student Id")]
        public string StudentId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string FathersName { get; set; }

        [Required]
        [Display(Name = "Mother Name")]
        public string MothersName { get; set; }

        [Required]
        [Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string StudentPhone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "DOB")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Gender")]
        public Gender GenderId { get; set; }

        public Boolean Ssc { get; set; }
        public Boolean Hsc { get; set; }
        public Boolean Bsc { get; set; }

        public string LastAcademicInfo { get; set; }
        public string NameOfInstitute { get; set; }
        public string NationalId { get; set; }
        [Required]
        [Display(Name = "Enrollment Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public string Picture { get; set; }

        [Required]
        [ForeignKey("Country")]
        [Display(Name = "Country")]
        public long CountryId { get; set; }

        [Required]
        [ForeignKey("State")]
        [Display(Name = "State")]
        public long StateId { get; set; }

        [Required]
        [ForeignKey("City")]
        [Display(Name = "City")]
        public long CityId { get; set; }

        [Required]
        [ForeignKey("Batch")]
        [Display(Name = "Batch")]
        public long BatchId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Display(Name = "Course Name")]
        public long CourseId { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public Batch Batch { get; set; }
        public Course Course { get; set; }
        public IList<Attendence> Attendences { get; set; }
        public IList<ExamResult> ExamResults { get; set; }
        public IList<Jobplacement> Jobplacements { get; set; }
        public IList<Attachment>Attachments { get; set; }
        public IList<AssignmentDetails> AssignmentDetails { get; set; }

    }
}
