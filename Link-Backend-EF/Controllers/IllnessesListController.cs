using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication.List;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources.Base;
using Link_Backend_EF.Resources;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class IllnessesListController : ControllerBase
    {
        private readonly IListRelationService<IllnessesList, IllnessesListResponse, IllnessesListListResponse> _service;
        private readonly IMapper _mapper;

        public IllnessesListController(IListRelationService<IllnessesList, IllnessesListResponse, IllnessesListListResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByUserCodeAsync(int id)
        {
            var model = await _service.ListByUserIdAsync(id);
            var resources = _mapper.Map<BaseResponse<List<IllnessesList>>, IllnessesListResource>(model);
            return Ok(resources);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveIllnessesListResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var data = _mapper.Map<SaveIllnessesListResource, IllnessesList>(resource);
            var result = await _service.SaveAsync(data);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<IllnessesList>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIllnessesListResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveIllnessesListResource, IllnessesList>(resource);
            var result = await _service.UpdateAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<IllnessesList>, ValidationResource>(result);
            return Ok(itemResource);
        }
    }
}
