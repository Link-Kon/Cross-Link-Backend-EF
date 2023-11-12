﻿using AutoMapper;
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
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipService _service;
        private readonly IMapper _mapper;

        public FriendshipController(IFriendshipService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("AccessProof/{user1Code}/{user2Code}")]
        public async Task<IActionResult> GetFriendshipProof(string user1Code, string user2Code)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _service.GetFriendshipProof(user1Code, user2Code);

            var itemResource = _mapper.Map<BaseResponse<Friendship>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpGet("{code}")]
        public async Task<IEnumerable<FriendshipListResponse>> GetAllByUserCodeAsync(string code)
        {
            var model = await _service.ListByUserCodeAsync(code);
            //var resources = _mapper.Map<IEnumerable<Friendship>, IEnumerable<FriendshipResource>>(models);
            return model;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveFriendshipResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var illness = _mapper.Map<SaveFriendshipResource, Friendship>(resource);
            var result = await _service.SaveAsync(illness);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<Friendship>, ValidationResource>(result);
            return Ok(itemResource);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFriendshipResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveFriendshipResource, Friendship>(resource);
            var result = await _service.UpdateAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<BaseResponse<Friendship>, ValidationResource>(result);
            return Ok(itemResource);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var result = await _illnessService.DeleteAsync(id);
        //    if (!result.Success)
        //        return BadRequest(result.Message);

        //    var itemResource = _mapper.Map<Illness, IllnessResource>(result.Resource);
        //    return Ok(itemResource);
        //}
    }
}