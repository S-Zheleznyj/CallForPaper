using CFP.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CallForPaper> CallForPapers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
    }
}
