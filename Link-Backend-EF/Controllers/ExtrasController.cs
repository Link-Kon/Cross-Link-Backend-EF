using Link_Backend_EF.Resources.Extras;
using Link_Backend_EF_Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Python.Runtime;
using System.Diagnostics;
using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;
using Link_Backend_EF.Resources.Base;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Resources;
using AutoMapper;
using Link_Backend_Google_Services.PushNotifications;
using Link_Backend_EF.Services.Base;

namespace Link_Backend_EF.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ExtrasController : ControllerBase
    {
        public readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly BasePuhNotification _basePuhNotification;
        private readonly ExtrasService _extrasService;

        public ExtrasController(IConfiguration config, HttpClient httpClient, IMapper mapper, BasePuhNotification basePuhNotification, ExtrasService extrasService)
        {
            _config = config;
            _httpClient = httpClient;
            _mapper = mapper;
            _basePuhNotification = basePuhNotification;
            _extrasService = extrasService;
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

        [HttpPost]
        [Route("GetHeartPrediction")]
        public async Task<IActionResult> GetHeartPrediction([FromBody] SaveArduinoHeartDataListResource Data)
        {
            try
            {
                object responseData = new object();

                var model = _mapper.Map<SaveArduinoHeartDataListResource, AWSHeartArduinoDataListResource>(Data);
                // Serialize the InputData object to JSON
                string jsonInput = JsonSerializer.Serialize(model);

                //HttpContent content = new StringContent(jsonInput, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = await _httpClient.PostAsync("https://wym2umlgx5.execute-api.us-east-2.amazonaws.com/default/GetData", content);

                //// Check if the response is successful
                //response.EnsureSuccessStatusCode();

                //// Deserialize the response JSON to the expected object
                //string jsonResponse = await response.Content.ReadAsStringAsync();
                //ValidationResource responseData = JsonSerializer.Deserialize<ValidationResource>(jsonResponse);

                List<TokenDevice> tokens = new List<TokenDevice>();
                tokens = await _extrasService.GetDevicesToken(Data.UserCode);
                List<TokenDevice> tokens2 = new List<TokenDevice>();
                tokens2.Add(new TokenDevice
                {
                    DeviceToken = "eovZ5kuRR8GtYFIytX5rKw:APA91bEoZ7Z7gWV-S3Cb73purrKu--4B5cgXoxGd9Ai8biu9RoxgAjOEkDjJUzb-F6ZPntIsn4gWy51JVel9VqhqzLlKu05NzoB9EM79i21VRwON7mRr1PfDCtH22PqsK8700ziKt__S"
                });

                await _basePuhNotification.SendNotifications("Prueba", "Patrick eres feo", tokens2);

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GetGyroPrediction")]
        public async Task<IActionResult> GetGyroPrediction([FromBody] SaveArduinoGyroDataListResource Data)
        {
            try
            {
                var model = _mapper.Map<SaveArduinoGyroDataListResource, AWSGyroArduinoDataListResource>(Data);
                // Serialize the InputData object to JSON
                string jsonInput = JsonSerializer.Serialize(model);

                HttpContent content = new StringContent(jsonInput, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("https://ngyrommg1a.execute-api.us-east-2.amazonaws.com/default/FallEvent2", content);

                // Check if the response is successful
                response.EnsureSuccessStatusCode();

                // Deserialize the response JSON to the expected object
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ValidationResource responseData = JsonSerializer.Deserialize<ValidationResource>(jsonResponse);

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
