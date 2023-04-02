using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public string AttachmentName { get; set; }
        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Student Name")]
        public long StudentId { get; set; }
        [Required]
        [ForeignKey("DocumentType")]
        [Display(Name = "DocumentType Name")]
        public long DocumentTypeId { get; set; }
        public Student Student { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
