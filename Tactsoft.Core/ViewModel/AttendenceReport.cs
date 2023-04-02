using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.ViewModel
{
    public class AttendenceReport
    {
        public AttendenceReport()
        {
            EmployeeAttendenceStatus = new List<EmployeeAttendenceStatus>();
            AllCurrentMonthDate = new List<string>();
        }

        [DisplayName("Batch")]
        [Required]
        public int BatchId { get; set; }

        [Required]
        [DisplayName("Course")]
        public int CourseId { get; set; }

        [Required]
        public int Month { get; set; }

        public List<string> AllCurrentMonthDate{ get; set; }
        public List<EmployeeAttendenceStatus> EmployeeAttendenceStatus { get; set; }
    }
    public class EmployeeAttendenceStatus
    {
        public EmployeeAttendenceStatus(int days, int month)
        {
            attendenceStatus = new List<AttendenceStatus>();

            for (int i = 1; i <= days; i++)
            {
                DateTime currentDate = new DateTime(DateTime.Now.Year, month, i);
                this.attendenceStatus.Add(new AttendenceStatus { Date = currentDate, Status = ""});
            }
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public List<AttendenceStatus> attendenceStatus { get; set; }
    }
    public class AttendenceStatus
    {
        public AttendenceStatus()
        {

        }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
