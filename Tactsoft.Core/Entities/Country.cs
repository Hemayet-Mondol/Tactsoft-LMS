using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.Entities
{
    public class Country:BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Flag { get; set; }


        public IList<State> States { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Organization> Organizations { get; set; }

    }
}
