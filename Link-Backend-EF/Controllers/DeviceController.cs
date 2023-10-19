using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Link_Backend_EF.Resources;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources.Base;

namespace Link_Backend_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IUserInfoService<Device, DeviceResponse> _service;
        private readonly IMapper _mapper;

        public DeviceController(IUserInfoService<Device, DeviceResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<DeviceResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<Device, DeviceResource>(model.Resource);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDeviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveDeviceResource, Device>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<Device>, ValidationResource>(result);

            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDeviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveDeviceResource, Device>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<Device>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<Device>, ValidationResource>(result);
            return Ok(itemResource);
        }
    }
}
