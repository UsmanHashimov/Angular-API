using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.API.Attributes;
using TicketingSystem.Application.Abstractions.IServices;
using TicketingSystem.Domain.Entities.DTOs;
using TicketingSystem.Domain.Entities.Enums;
using TicketingSystem.Domain.Entities.Models;

namespace TicketingSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPatch]
        public async Task<string> PurchaseTicket(string email, string password, int id)
        {
            var res = await _ticketService.PurchaseTicket(email, password, id);

            return res;
        }

        [HttpPost]
        public async Task<string> AddTicket([FromForm] TicketDTO ticketDTO)
        {
            var res = await _ticketService.Create(ticketDTO);
            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _ticketService.GetAll();
        }

        [HttpGet]
        [IdentityFilter(Permission.GetByTicketId)]
        public async Task<Ticket> GetTicketById(int id)
        {
            var res = await _ticketService.GetById(id);
            return res;
        }

        [HttpGet]
        public async Task<Ticket> GetByTicketName(string name)
        {
            var res = await _ticketService.GetByName(name);
            return res;
        }


        [HttpPut]
        public async Task<string> UpdateTicket(int id,[FromForm] TicketDTO ticketDTO)
        {
            var res = await _ticketService.Update(id, ticketDTO);

            return res;
        }

        [HttpDelete]
        public async Task<bool> DeleteTicket(int id)
        {
            var res = await _ticketService.Delete(id);

            return res;
        }
    }
}
