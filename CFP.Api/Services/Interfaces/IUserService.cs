using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> Create(UserCreateRequest request);
        public Task<User> GetById(Guid id);
        public Task<string> Login(string login, string password);
    }
}
