using TicketingSystem.Application.Abstractions.IRepositories;
using TicketingSystem.Domain.Entities.Models;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDBContext context) : base(context) { }
    }
}
