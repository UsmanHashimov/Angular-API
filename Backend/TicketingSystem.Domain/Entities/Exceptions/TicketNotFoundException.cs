namespace TicketingSystem.Domain.Entities.Exceptions
{
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(string message) : base(message) { }
    }
}
