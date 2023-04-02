using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class UserType:BaseEntity
    {
       public string UserTypeName { get; set; }
        public IList<User> User { get; set; }
    }
}
