using TicketingSystem.Domain.Entities.DTOs;
using TicketingSystem.Domain.Entities.ViewModels;

namespace TicketingSystem.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<string> Create(UserDTO userDTO);
        public Task<UserViewModel> GetByName(string name);
        public Task<UserViewModel> GetById(int Id);
        public Task<UserViewModel> GetByEmail(string email);
        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<string> Delete(int id);
        public Task<string> Update(int Id, UserDTO userDTO);
        public Task<string> GetPdfPath();
    }
}
