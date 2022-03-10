using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineAuction.Core.Entities;

namespace OnlineAuction.Infrastructure.Data
{
    public class WebAppContext:IdentityDbContext<AppUser>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options):base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
