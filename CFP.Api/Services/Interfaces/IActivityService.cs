using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Services.Interfaces
{
    public interface IActivityService
    {
        Task<Guid> Create(ActivityCreateRequest item);
        Task<List<Activity>> Get();
    }
}
