using CFP.Api.Models.Entities;

namespace CFP.Api.Data.Interfaces
{
    public interface IUserRepo
    {
        public Task<Guid> Create(User item);
        public Task<User> GetById(Guid id);
        public Task<User> GetByLogin(string login);
    }
}
