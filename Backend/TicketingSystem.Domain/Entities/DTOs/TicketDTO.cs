using TicketingSystem.Domain.Entities.Models;

namespace TicketingSystem.Domain.Entities.DTOs
{
    public class TicketDTO
    {
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public int OrganisatorId { get; set; }
    }
}
