using CFP.Api.Models.DTOs;
using CFP.Api.Models.Entities;
using CFP.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _service;

        public ActivityController(IActivityService service)
        {
            _service = service;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<Guid> Create(ActivityCreateRequest request)
        {
            return await _service.Create(request);
        }

        [HttpGet]
        public async Task<List<Activity>> Get()
        {
            return await _service.Get();
        }
    }
}
