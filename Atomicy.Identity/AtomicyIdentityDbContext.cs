using Atomicy.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atomicy.Identity
{
    public class AtomicyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AtomicyIdentityDbContext(DbContextOptions<AtomicyIdentityDbContext> options) : base(options)
        {
        }

    }
}
