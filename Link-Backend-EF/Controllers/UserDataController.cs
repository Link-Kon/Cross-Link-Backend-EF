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
    public class UserDataController : ControllerBase
    {
        private readonly IUserInfoService<UserData, UserDataResponse> _service;
        private readonly IUserDataService _userDataService;
        private readonly IMapper _mapper;

        public UserDataController(IUserInfoService<UserData, UserDataResponse> service, IUserDataService userDataService, IMapper mapper)
        {
            _service = service;
            _userDataService = userDataService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<UserDataResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<UserData, UserDataResource>(model.Resource);
            return resource;
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<UserDataResource> GetByEmailAsync(string username)
        {
            var model = await _service.FindByStringAsync(username);
            var resources = _mapper.Map<UserData, UserDataResource>(model.Resource);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserDataResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveUserDataResource, UserData>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<UserData>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserDataResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveUserDataResource, UserData>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<UserData>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<UserData>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpGet("{code}/{sharedId}")]
        public async Task<UserDataResource> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            var model = await _service.FindByCodeAndSharedIdAsync(code, sharedId);
            var resource = _mapper.Map<UserData, UserDataResource>(model.Resource);
            return resource;
        }

        [HttpGet("friend/{user1Code}/{user2Code}")]
        public async Task<UserDataResource> FindByFriendAsync(string user1Code, string user2Code)
        {
            var model = await _userDataService.FindByFriendAsync(user1Code, user2Code);
            var resource = _mapper.Map<UserData, UserDataResource>(model.Resource);
            if (resource == null)
            {
                resource = new UserDataResource();
            }
            return resource;
        }
    }
}