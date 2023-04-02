using Tactsoft.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Entities
{
    public class Employee : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }

        
        [Display(Name = "Department")]
        public long? DepartmentId { get; set; }

        [Required]
        [Display(Name = "Joining Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime JoiningDate { get; set; }
        public Boolean Ssc { get; set; }
        public Boolean Hsc { get; set; }
        public Boolean Bsc { get; set; }
        public Boolean Msc { get; set; }

        public string Picture { get; set; }

        [Required]
        [ForeignKey("Country")]
        [Display(Name = "Country Name")]
        public long CountryId { get; set; }

        [Required]
        [ForeignKey("State")]
        [Display(Name = "State Name")]
        public long StateId { get; set; }

        [Required]
        [ForeignKey("City")]
        [Display(Name = "City Name")]
        public long CityId { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }

        public Department Department { get; set; }
    }
}
