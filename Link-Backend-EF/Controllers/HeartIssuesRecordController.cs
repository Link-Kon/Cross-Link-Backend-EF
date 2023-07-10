using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources;
using Link_Backend_EF.Resources.Base;
using Microsoft.AspNetCore.Mvc;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HeartIssuesRecordController : ControllerBase
    {
        private readonly IHealthRecordService<HeartIssuesRecord, HeartIssuesRecordResponse> _service;
        private readonly IMapper _mapper;

        public HeartIssuesRecordController(IHealthRecordService<HeartIssuesRecord, HeartIssuesRecordResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<HeartIssuesRecordResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<HeartIssuesRecord, HeartIssuesRecordResource>(model.Resource);
            return resource;
        }

        [HttpGet("PatientId/{id}")]
        public async Task<HeartIssuesRecordResource> GetByPatientIdAsync(int id)
        {
            var model = await _service.FindByPatiendIdAsync(id);
            var resource = _mapper.Map<HeartIssuesRecord, HeartIssuesRecordResource>(model.Resource);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHeartIssuesRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveHeartIssuesRecordResource, HeartIssuesRecord>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<HeartIssuesRecord>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHeartIssuesRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveHeartIssuesRecordResource, HeartIssuesRecord>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<HeartIssuesRecord>, ValidationResource>(result);
            return Ok(itemResource);
        }
    }
}