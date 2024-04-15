using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities.Models;

namespace TicketingSystem.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        => Database.Migrate();

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}
