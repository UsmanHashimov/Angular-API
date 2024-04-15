using TicketingSystem.Application.Abstractions.IRepositories;
using TicketingSystem.Domain.Entities.Models;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context) { }
    }
}
