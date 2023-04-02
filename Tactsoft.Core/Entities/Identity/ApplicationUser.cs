using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tactsoft.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public long CreatedUserId { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public long UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
    }
}
