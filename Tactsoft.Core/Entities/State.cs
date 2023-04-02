using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Tactsoft.Core.Entities
{
    public class State:BaseEntity
    {        
        public string Name { get; set; }
        public long CountryId { get; set; }

        public Country Country { get; set; }

        public IList<City> Cities { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Organization> Organizations { get; set; }
    }
}
