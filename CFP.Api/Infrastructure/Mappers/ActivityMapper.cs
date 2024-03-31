using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Infrastructure.Mappers
{
    public class ActivityMapper
    {
        public Activity MapFrom(ActivityCreateRequest request)
        {
            return new()
            {
                Name = request.Name
            };
        }
    }
}
