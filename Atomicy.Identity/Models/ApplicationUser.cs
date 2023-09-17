using Microsoft.AspNetCore.Identity;

namespace Atomicy.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirmName { get; set; }
        public bool Firm { get; set; }
    }
}
