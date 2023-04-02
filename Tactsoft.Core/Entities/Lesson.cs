using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Lesson : BaseEntity
    {

        public int LessonNumber { get; set; }
        [Required]
        public string LessonName { get; set; }
        public string LessonPdf { get; set; }

        [ForeignKey("Course")]
        [Display(Name = "Course Name")]
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public IList<ClassVideo> ClassVideos { get; set; }

    }
}
