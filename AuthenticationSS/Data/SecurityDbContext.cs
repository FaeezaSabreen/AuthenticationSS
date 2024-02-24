using Microsoft.EntityFrameworkCore;

namespace AuthenticationSS.Data
{
    public class SecurityDbContext : IdentityDbContext<IdentityUser>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
        }

       
    }
}
