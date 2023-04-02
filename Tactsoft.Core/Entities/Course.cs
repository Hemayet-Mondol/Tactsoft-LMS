using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public float CourseFee { get; set; }
        public string CoursePageUrl { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category Name")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<Lesson> Lessons { get; set; }
        public IList<Batch> Batchs { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Assignment> Assignments { get; set; }
        public IList<Link> Links { get; set; }
    }
}
