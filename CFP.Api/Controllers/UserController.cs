using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;
using CFP.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<Guid> Register(UserCreateRequest request)
        {
            return await _service.Create(request);
        }

        [HttpPost("Login")]
        public async Task<string> Login(string login, string password)
        {
            return await _service.Login(login, password);
        }
    }
}
