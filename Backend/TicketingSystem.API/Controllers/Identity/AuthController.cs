//using Microsoft.AspNetCore.Mvc;
//using TicketingSystem.Application.Abstractions.IServices;
//using TicketingSystem.Domain.Entities.DTOs;
//using TicketingSystem.Domain.Entities.Models;

//namespace TicketingSystem.API.Controllers.Identity
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]

//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authSevice;
//        public AuthController(IAuthService authService)
//        {
//            _authSevice = authService;
//        }

//        [HttpPost]
//        public async Task<ActionResult<ResponceLogin>> Login([FromForm] RequestLogin model)
//        {
//            var result = await _authSevice.GenerateToken(model);

//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<string>> SignUp([FromForm] UserDTO model)
//        {
//            var result = await _authSevice.SignUp(model);

//            return Ok(result);
//        }
//    }
//}
