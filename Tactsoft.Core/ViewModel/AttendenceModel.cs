using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.ViewModel
{
    public class AttendenceModel
    {
        public AttendenceModel()
        {
            AttendenceList = new Collection<AttendenceList>();
            AttendenceDate = DateTime.Now;
        }

        [Required]
        [DisplayName("Batch")]
        public int BatchId { get; set; }
        [Required]
        [DisplayName("Course")]
        public int CourseId { get; set; }

        [Required]
        [DisplayName("Attendence Date")]
        public DateTime AttendenceDate { get; set; }

        public ICollection<AttendenceList> AttendenceList { get; set; }
    }

    public class AttendenceList
    {
        public long AttendenceId { get; set; }
        public long StudentId { get; set; }
        public long BatchId { get; set; }
        public string Name { get; set; }
        public Boolean IsPresent { get; set; }
    }
}
