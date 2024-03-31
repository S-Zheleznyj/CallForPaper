using CFP.Api.Models.Entities;

namespace CFP.Api.Data.Interfaces
{
    public interface ICallForPaperRepo
    {
        Task<Guid> Create(CallForPaper item);
        Task Update(CallForPaper item);
        Task Remove(CallForPaper item);
        Task<List<CallForPaper>> Get(CallForPaperStatus status, DateTime dateFrom);
        Task<CallForPaper> GetById(Guid id);
        Task<List<CallForPaper>> GetByUserId(Guid userId);
    }
}
