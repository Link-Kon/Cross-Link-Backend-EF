using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class IllnessController : ControllerBase
    {
        private readonly IIllnessService _illnessService;
        private readonly IMapper _mapper;

        public IllnessController(IIllnessService illnessService, IMapper mapper)
        {
            _illnessService = illnessService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<IllnessResource>> GetAllAsync()
        {
            var illnesses = await _illnessService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Illness>, IEnumerable<IllnessResource>>(illnesses);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveIllnessResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var illness = _mapper.Map<SaveIllnessResource, Illness>(resource);
            var result = await _illnessService.SaveAsync(illness);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Illness, IllnessResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIllnessResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var illness = _mapper.Map<SaveIllnessResource, Illness>(resource);
            var result = await _illnessService.UpdateAsync(id, illness);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Illness, IllnessResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _illnessService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Illness, IllnessResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}
