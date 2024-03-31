using CFP.Api.Data.Interfaces;
using CFP.Api.Infrastructure.ExceptionHandling;
using CFP.Api.Infrastructure.Mappers;
using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;
using CFP.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CFP.Api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly UserMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IUserRepo repo, UserMapper mapper, IConfiguration config)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
        }

        public async Task<Guid> Create(UserCreateRequest request)
        {
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = _mapper.MapFrom(request);
            return await _repo.Create(user);
        }

        public async Task<User> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task<string> Login(string login, string password)
        {
            var user = await _repo.GetByLogin(login);
            if (user != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    throw new HttpResponseException(400, "Wrong login or password");
                }
            }
            var token = CreateToken(user);

            return token;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
