using CFP.Api.Data.Interfaces;
using CFP.Api.Infrastructure.Extensions;
using CFP.Api.Infrastructure.Mappers;
using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;
using CFP.Api.Services.Interfaces;

namespace CFP.Api.Services.Implementations
{
    public class CallForPaperService : ICallForPaperService
    {
        private readonly ICallForPaperRepo _repo;
        private readonly CallForPaperMapper _mapper;

        public CallForPaperService(ICallForPaperRepo repo, CallForPaperMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> Create(CallForPaperCreateRequest item)
        {
            var callForPaper = _mapper.MapFrom(item);
            return await _repo.Create(callForPaper);
        }

        public async Task<List<CallForPaper>> Get(CallForPaperStatus status, DateTime dateFrom)
        {
            return await _repo.Get(status, dateFrom);
        }

        public async Task<CallForPaper> Get(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task<CallForPaper> GetUserDraft(Guid userId)
        {
            var userCfps = await _repo.GetByUserId(userId);
            return userCfps.FirstOrDefault(x => x.CallForPaperStatus == CallForPaperStatus.Draft);
        }

        public async Task Remove(Guid id)
        {
            var itemToRemove = await Get(id);
            if (itemToRemove != null)
            {
                await _repo.Remove(itemToRemove);
            }
        }

        public async Task Update(CallForPaperUpdateRequest item)
        {
            var itemToUpdate = await Get(item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Set(item);
                await _repo.Update(itemToUpdate);
            }
        }
    }
}
