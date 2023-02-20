using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HeartRhythmRecordController : ControllerBase
    {
        private readonly IHealthRecordService<HeartRhythmRecord, HeartRhythmRecordResponse> _service;
        private readonly IMapper _mapper;

        public HeartRhythmRecordController(IHealthRecordService<HeartRhythmRecord, HeartRhythmRecordResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<HeartRhythmRecordResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<HeartRhythmRecord, HeartRhythmRecordResource>(model.Resource);
            return resource;
        }

        [HttpGet("PatientId/{id}")]
        public async Task<HeartRhythmRecordResource> GetByPatientIdAsync(int id)
        {
            var model = await _service.FindByPatiendIdAsync(id);
            var resource = _mapper.Map<HeartRhythmRecord, HeartRhythmRecordResource>(model.Resource);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHeartRhythmRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveHeartRhythmRecordResource, HeartRhythmRecord>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<HeartRhythmRecord, HeartRhythmRecordResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHeartRhythmRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveHeartRhythmRecordResource, HeartRhythmRecord>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<HeartRhythmRecord, HeartRhythmRecordResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}