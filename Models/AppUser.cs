using Microsoft.AspNetCore.Identity;

namespace projetotg.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
    }
}