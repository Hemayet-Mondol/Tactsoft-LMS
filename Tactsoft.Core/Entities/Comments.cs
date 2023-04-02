using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Comments:BaseEntity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
