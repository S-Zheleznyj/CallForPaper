using CFP.Api.Data.Interfaces;
using CFP.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Api.Data.Implementations
{
    public class ActivityRepo : IActivityRepo
    {
        private readonly ApplicationContext _context;

        public ActivityRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Activity item)
        {
            await _context.Activities.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<List<Activity>> Get()
        {
            return await _context.Activities.ToListAsync();
        }
    }
}
