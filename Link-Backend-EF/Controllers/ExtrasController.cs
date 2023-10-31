﻿using Link_Backend_EF.Resources.Extras;
using Link_Backend_EF_Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Python.Runtime;
using System.Diagnostics;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ExtrasController : ControllerBase
    {
        public readonly IConfiguration _config;

        public ExtrasController(IConfiguration config)
        {
            _config = config;
        }

        // POST api/<TokenController>
        [HttpPost]
        [AllowAnonymous]
        [Route("GetToken")]
        public async Task<object> GetToken([FromBody] string AccessToken)
            {
            try
            {
                string keyV = _config["AES:Key"];
                string iv = _config["AES:AES_IV"];

                var DescAccessToken = AESEncDec.AESDecryption(AccessToken, keyV, iv);

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, AccessToken),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: signIn);

                var res = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

                return res;
            }
            catch (Exception ex)
            {
                var res = StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Message = " + ex.Message + ", Stacktrace = " + ex.StackTrace + ", TargetSite = " + ex.TargetSite + ",InnerException = " + ex.InnerException });
                return res;
            }
        }

        [HttpGet]
        [Route("GetData")]
        public async Task GetData([FromBody] SaveArduinoDataListResource Data)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Authorize]
        [Route("TryAuthorize")]
        public bool TryAuthorize()
        {
            return true;
        }
    }
}
