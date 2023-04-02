using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Department:BaseEntity
    {
        [Required]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }


        public IList<Employee> Employees { get; set; }
        public IList<Jobplacement> Jobplacements{ get; set; }
    }
}
