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
    public class PatientController : ControllerBase
    {
        private readonly IUserInfoService<Patient, PatientResponse> _service;
        private readonly IMapper _mapper;

        public PatientController(IUserInfoService<Patient, PatientResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<PatientResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<Patient, PatientResource>(model.Resource);
            return resource;
        }

        [HttpGet("GetByUserDataId/{id}")]
        public async Task<PatientResource> GetByUserDataIdAsync(int id)
        {
            var model = await _service.FindByStringAsync(id.ToString());
            var resources = _mapper.Map<Patient, PatientResource>(model.Resource);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SavePatientResource, Patient>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SavePatientResource, Patient>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}