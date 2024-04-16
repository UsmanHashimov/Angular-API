using System.ComponentModel.DataAnnotations.Schema;
using TicketingSystem.Domain.Entities.ViewModels;

namespace TicketingSystem.Domain.Entities.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public int OrganisatorId { get; set; }

        [ForeignKey(nameof(OrganisatorId))]
        public virtual User Organizator { get; set; }
    }
}
