using Microsoft.AspNetCore.Identity;

namespace projetotg.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NewPassword { get; set; }
    }
}