using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;
using CFP.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallForPaperController : Controller
    {
        private readonly ICallForPaperService _service;

        public CallForPaperController(ICallForPaperService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<Guid> Create(CallForPaperCreateRequest request)
        {
            return await _service.Create(request);
        }

        [HttpPut]
        public async Task Update(CallForPaperUpdateRequest request)
        {
            await _service.Update(request);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _service.Remove(id);
        }

        [HttpGet("{id}")]
        public async Task<CallForPaper> Get(Guid id)
        {
            return await _service.Get(id);
        }

        [HttpGet("UserDraft")]
        public async Task<CallForPaper> GetUserDraft(Guid userId)
        {
            return await _service.GetUserDraft(userId);
        }

        [HttpGet("Sended")]
        public async Task<List<CallForPaper>> GetSended(DateTime dateFrom)
        {
            return await _service.Get(CallForPaperStatus.SendForReview, dateFrom);
        }

        [HttpGet("Drafts")]
        public async Task<List<CallForPaper>> GetDrafts(DateTime dateFrom)
        {
            return await _service.Get(CallForPaperStatus.Draft, dateFrom);
        }
    }
}
