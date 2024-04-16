using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TicketingSystem.Domain.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [EmailAddress,JsonIgnore]
        public string Login { get; set; }

        [MinLength(6),JsonIgnore]
        public string Password { get; set; }
        public string role { get; set; }
        public int TicketId { get; set; }
    }
}
