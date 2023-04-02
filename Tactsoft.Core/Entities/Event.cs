using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventPicture { get; set; }
    }
}
