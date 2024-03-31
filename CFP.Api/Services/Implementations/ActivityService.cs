using CFP.Api.Data.Interfaces;
using CFP.Api.Infrastructure.Mappers;
using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;
using CFP.Api.Services.Interfaces;

namespace CFP.Api.Services.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepo _repo;
        private readonly ActivityMapper _mapper;

        public ActivityService(IActivityRepo repo, ActivityMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Guid> Create(ActivityCreateRequest item)
        {
            var activity = _mapper.MapFrom(item);
            return await _repo.Create(activity);
        }

        public async Task<List<Activity>> Get()
        {
            return await _repo.Get();
        }
    }
}
