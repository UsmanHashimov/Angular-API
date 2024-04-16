namespace TicketingSystem.Domain.Entities.Enums
{
    public enum Permission
    {
        GetAllUsers = 2,
        GetByUserName = 3,
        GetByUserId = 4,
        GetByUserEmail = 5,
        UpdateUser = 6,
        DeleteUser = 7,
        AddTicket = 8,
        GetByTicketId = 9,
        GetByTicketName = 10,
        GetAllTickets = 11,
        UpdateTicket = 12,
        DeleteTicket = 13,
        GetUserPDF = 14,
        PurchaseTicket = 15
    }
}
