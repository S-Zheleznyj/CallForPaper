using CFP.Api.Data;
using CFP.Api.Data.Implementations;
using CFP.Api.Data.Interfaces;
using CFP.Api.Infrastructure.ExceptionHandling;
using CFP.Api.Infrastructure.Mappers;
using CFP.Api.Services.Implementations;
using CFP.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CFP.Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            RegisterRepos(services);
            RegisterMappers(services);
            RegisterServices(services);

            services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICallForPaperService, CallForPaperService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddSingleton<CallForPaperMapper>();
            services.AddSingleton<ActivityMapper>();
            services.AddSingleton<UserMapper>();
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            services.AddScoped<ICallForPaperRepo, CallForPaperRepo>();
            services.AddScoped<IActivityRepo, ActivityRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}
