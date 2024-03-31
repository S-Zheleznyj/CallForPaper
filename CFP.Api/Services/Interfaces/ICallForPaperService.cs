using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Services.Interfaces
{
    public interface ICallForPaperService
    {
        Task<Guid> Create(CallForPaperCreateRequest item);
        Task Update(CallForPaperUpdateRequest item);
        Task Remove(Guid id);
        Task<List<CallForPaper>> Get(CallForPaperStatus status, DateTime dateFrom);
        Task<CallForPaper> Get(Guid id);
        Task<CallForPaper> GetUserDraft(Guid userId);
    }
}
