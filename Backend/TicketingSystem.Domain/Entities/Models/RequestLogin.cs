using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Domain.Entities.Models
{
    public class RequestLogin
    {
        [EmailAddress]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
