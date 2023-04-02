using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Batch : BaseEntity
    {
        public string BatchName { get; set; }
        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }
        public string Slote { get; set; }
        [Display(Name = "Batch Status")]
        public string BatchStatus { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Remarks { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Display(Name = "Course Name")]
        public long CourseId { get; set; }

        [Required]
        [ForeignKey("ClassRoom")]
        [Display(Name = "Class Room")]
        public long ClassRoomId { get; set; }

        [Required]
        [ForeignKey("Trainer")]
        [Display(Name = "Trainer Name")]
        public long TrainerId { get; set; }

        [Required]
        [ForeignKey("Venue")]
        [Display(Name = "Venue Name")]
        public long VenueId { get; set; }

        public Course Course { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Trainer Trainer { get; set; }
        public Venue Venue { get; set; }

        public IList<Student> Students { get; set; }
        public IList<Attendence> Attendences { get; set; }
        public IList<Assignment> Assignments { get; set; }
        public IList<Link> Links { get; set; }

    }
}
