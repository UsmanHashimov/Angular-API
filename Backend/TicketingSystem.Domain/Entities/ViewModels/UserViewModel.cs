
using TicketingSystem.Domain.Entities.Models;

namespace TicketingSystem.Domain.Entities.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int TicketId { get; set; }
    }
}
