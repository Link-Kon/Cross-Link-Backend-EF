using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources;
using Link_Backend_EF.Services;
using Microsoft.AspNetCore.Mvc;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FallRecordController : ControllerBase
    {
        private readonly IHealthRecordService<FallRecord, FallRecordResponse> _service;
        private readonly IMapper _mapper;

        public FallRecordController(IHealthRecordService<FallRecord, FallRecordResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<FallRecordResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<FallRecord, FallRecordResource>(model.Resource);
            return resource;
        }

        [HttpGet("PatientId/{id}")]
        public async Task<FallRecordResource> GetByPatientIdAsync(int id)
        {
            var model = await _service.FindByPatiendIdAsync(id);
            var resource = _mapper.Map<FallRecord, FallRecordResource>(model.Resource);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveFallRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveFallRecordResource, FallRecord>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<FallRecord, FallRecordResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFallRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveFallRecordResource, FallRecord>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<FallRecord, FallRecordResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}