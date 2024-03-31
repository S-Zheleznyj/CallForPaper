using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;

namespace CFP.Api.Infrastructure.Extensions
{
    public static class CallForPaperExtension
    {
        public static void Set(this CallForPaper setTo, CallForPaperUpdateRequest setFrom)
        {
            if (setFrom.ActivityId != null)
            {
                setTo.ActivityId = setFrom.ActivityId.Value;
            }
            if (!string.IsNullOrEmpty(setFrom.Name))
            {
                setTo.Name = setFrom.Name;
            }
            if (!string.IsNullOrEmpty(setFrom.Plan))
            {
                setTo.Plan = setFrom.Plan;
            }
            if (setFrom.Description != null)
            {
                setTo.Description = setFrom.Description;
            }
            if (setFrom.CallForPaperStatus != null)
            {
                setTo.CallForPaperStatus = setFrom.CallForPaperStatus.Value;
            }
            setTo.UpdatedDate = DateTime.UtcNow;
        }
    }
}
