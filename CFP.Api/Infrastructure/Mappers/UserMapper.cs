using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Infrastructure.Mappers
{
    public class UserMapper
    {
        public User MapFrom(UserCreateRequest request)
        {
            return new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Login = request.Login,
                Phone = request.Phone,
                PasswordHash = request.Password
            };
        }
    }
}
