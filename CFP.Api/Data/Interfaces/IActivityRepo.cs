using CFP.Api.Models.Entities;

namespace CFP.Api.Data.Interfaces
{
    public interface IActivityRepo
    {
        Task<Guid> Create(Activity item);
        Task<List<Activity>> Get();
    }
}
