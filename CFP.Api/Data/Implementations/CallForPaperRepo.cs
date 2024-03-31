using CFP.Api.Data.Interfaces;
using CFP.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Api.Data.Implementations
{
    public class CallForPaperRepo : ICallForPaperRepo
    {
        private readonly ApplicationContext _context;

        public CallForPaperRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CallForPaper item)
        {
            await _context.CallForPapers.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<CallForPaper> GetById(Guid id)
        {
            return await _context.CallForPapers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CallForPaper>> Get(CallForPaperStatus status, DateTime dateFrom)
        {
            return await _context.CallForPapers.Where(x => x.CallForPaperStatus == status &&
                x.UpdatedDate >= dateFrom).ToListAsync();
        }

        public async Task<List<CallForPaper>> GetByUserId(Guid userId)
        {
            return await _context.CallForPapers.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task Remove(CallForPaper item)
        {
            _context.CallForPapers.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CallForPaper item)
        {
            _context.CallForPapers.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
