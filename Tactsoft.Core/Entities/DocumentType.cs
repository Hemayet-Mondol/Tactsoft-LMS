using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class DocumentType:BaseEntity
    {
        public string DocumentName { get; set; }
        public IList<Attachment> Attachments { get; set; }
    }
}
