using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Venue: BaseEntity
    {
   
        public string VenuName { get; set;}
        public string Address { get; set;}
        public string VenueContactNo { get; set;}
        public IList<Batch> Batchs { get; set; }
    }
}
