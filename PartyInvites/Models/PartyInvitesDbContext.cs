using Microsoft.EntityFrameworkCore;

namespace PartyInvites.Models
{
    public class PartyInvitesDbContext : DbContext
    {
        public PartyInvitesDbContext(DbContextOptions<PartyInvitesDbContext> options) : base(options)
        {
            
        }

        public DbSet<GuestResponse> GuestResponses { get; set; }
    }
}
