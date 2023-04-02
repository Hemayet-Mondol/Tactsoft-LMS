using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class ClassVideo : BaseEntity
    {
        public string VideoFileName { get; set; }
        public string VideoUrl { get; set; }
        [Required]
        [ForeignKey("Lesson")]
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
