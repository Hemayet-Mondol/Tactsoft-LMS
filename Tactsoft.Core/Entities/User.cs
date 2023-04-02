using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("UserType")]
        [Display(Name = "User Type")]
        public long UserTypeId { get; set; }
        public UserType UserType { get; set; }
        
    }
}
