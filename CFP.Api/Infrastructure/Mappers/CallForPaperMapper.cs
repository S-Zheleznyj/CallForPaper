using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Infrastructure.Mappers
{
    public class CallForPaperMapper
    {
        public CallForPaper MapFrom(CallForPaperCreateRequest request)
        {
            return new()
            {
                ActivityId = request.ActivityId,
                CallForPaperStatus = CallForPaperStatus.Draft,
                Description = request.Description,
                Name = request.Name,
                Plan = request.Plan,
                UserId = request.UserId
            };
        }
    }
}
