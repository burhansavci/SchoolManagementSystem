using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [MaxLength(11)]
        public string TCNo { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; } 
        [MaxLength(255)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}
