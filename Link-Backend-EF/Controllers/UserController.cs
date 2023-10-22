using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Extensions;
using Link_Backend_EF.Resources;
using Link_Backend_EF.Resources.Base;
using Link_Backend_EF.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoService<User, UserResponse> _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public readonly ExtrasService _extrasService;

        public UserController(IUserInfoService<User, UserResponse> service, IUserService userService, IMapper mapper, ExtrasService extrasService)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
            _extrasService = extrasService;
        }

        [HttpGet("{id}")]
        public async Task<UserResource> GetByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<User, UserResource>(model.Resource);
            return resource;
        }

        [HttpGet("GetByUsername/{username}")]
        public async Task<UserPublicResource> GetByUsernameAsync(string username)
        {
            var model = await _service.FindByStringAsync(username);
            var resources = _mapper.Map<UserData, UserPublicResource>(model.Resource2);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            resource.Token = await _extrasService.GetToken(resource.Token);
            var model = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<User>, ValidationResource>(result);

            resource.Token = await _extrasService.EncryptToken(resource.Token);
                
            var res = new { itemResource, token = result.Resource.Token, result.Resource.Code };

            return Ok(res);
        }

        [HttpPost]
        [Route("GetReToken")]
        public async Task<IActionResult> GetReToken([FromBody] SaveTokenValidationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            resource.OldToken = await _extrasService.DecryptToken(resource.OldToken);
            resource.NewToken = await _extrasService.GetToken(resource.NewToken);
            var model = _mapper.Map<SaveTokenValidationResource, TokenValidationResource>(resource);

            var result = await _userService.FindByIdAndOldTokenAsync(model);

            //if (!result.Success)
            //    return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<User>, ValidationResource>(result);

            if (itemResource.Success)
            {
                resource.NewToken = await _extrasService.EncryptToken(resource.NewToken);

                var res = new { itemResource, token = resource.NewToken };
                return Ok(res);
            }

            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            resource.Token = await _extrasService.GetToken(resource.Token);

            var model = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<User>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<User>, ValidationResource>(result);
            return Ok(itemResource);
        }
    }
}