using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace projetotg.Models
{
    public class IdentityAppContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
                  
        }
    }
}