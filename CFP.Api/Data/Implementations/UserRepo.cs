using CFP.Api.Data.Interfaces;
using CFP.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Api.Data.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationContext _context;

        public UserRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(User item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
