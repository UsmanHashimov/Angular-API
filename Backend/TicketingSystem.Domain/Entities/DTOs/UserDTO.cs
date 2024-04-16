using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketingSystem.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore,EmailAddress]
        public string Login { get; set; }
        [MinLength(6),JsonIgnore]
        public string Password { get; set; }
        public string role { get; set; }
    }
}
