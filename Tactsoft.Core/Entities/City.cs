using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tactsoft.Core.Entities
{
    public class City:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "State")]
        public long StateId { get; set; }

        public State State { get; set; }

        public IList<Student> Students { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Organization> Organizations { get; set; }
    }
}
