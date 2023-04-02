using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class ClassRoom:BaseEntity
    {
        [Display(Name ="Class Room Number")]
        public int ClassRoomNumber { get; set; }
        [Display(Name = "Class Room Name")]
        public string ClassRoomName { get; set; }

        public IList<Batch> Batchs { get; set; }
    }
}
