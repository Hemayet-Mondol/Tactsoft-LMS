using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Organization : BaseEntity
    {

        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Establishment { get; set; }
        public string Description { get; set; }
        public string TypeOfOrg { get; set; }
        public string ContactPerson { get; set; }
        public string Logo { get; set; }


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
        public IList<Jobplacement> Jobplacements { get; set; }
    }
}
