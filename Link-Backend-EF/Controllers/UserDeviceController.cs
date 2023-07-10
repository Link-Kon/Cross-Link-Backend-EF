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
    public class UserDeviceController : ControllerBase
    {
        private readonly IUserDeviceService _service;
        private readonly IMapper _mapper;

        public UserDeviceController(IUserDeviceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UserDeviceResource>> GetAllByUserCodeAsync(int id)
        {
            var models = await _service.ListByUserIdAsync(id);
            var resources = _mapper.Map<IEnumerable<UserDevice>, IEnumerable<UserDeviceResource>>(models);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserDeviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var data = _mapper.Map<SaveUserDeviceResource, UserDevice>(resource);
            var result = await _service.SaveAsync(data);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<UserDevice>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserDeviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveUserDeviceResource, UserDevice>(resource);
            var result = await _service.UpdateAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<UserDevice>, ValidationResource>(result);
            return Ok(itemResource);
        }
    }
}
