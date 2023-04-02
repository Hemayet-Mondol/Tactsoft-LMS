using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public IList<Course> Courses { get; set; }
    }
}
