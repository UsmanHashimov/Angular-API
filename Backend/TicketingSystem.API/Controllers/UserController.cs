using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.API.Attributes;
using TicketingSystem.Application.Abstractions.IServices;
using TicketingSystem.Domain.Entities.DTOs;
using TicketingSystem.Domain.Entities.Enums;
using TicketingSystem.Domain.Entities.Models;
using TicketingSystem.Domain.Entities.ViewModels;

namespace TicketingSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class bUserController : ControllerBase
    {
        private readonly IUserService _userService;
        public bUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var result = await _userService.GetAll();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetUserByID(int id)
        {
            var res = await _userService.GetById(id);
            return res;
        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetUserByEmail(string email)
        {
            var res = await _userService.GetByEmail(email);
            return res;
        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetUserByName(string name)
        {
            var res = await _userService.GetByName(name);
            return res;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            var filePath = await _userService.GetPdfPath();

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");


            var fileBytes = System.IO.File.ReadAllBytes(filePath);


            var contentType = "application/octet-stream";

            var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();

            return File(fileBytes, contentType, Path.GetFileName(filePath));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            var res = await _userService.Delete(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateUser(int id, [FromForm] UserDTO userDTO)
        {
            return await _userService.Update(id, userDTO);
        }
    }
}
