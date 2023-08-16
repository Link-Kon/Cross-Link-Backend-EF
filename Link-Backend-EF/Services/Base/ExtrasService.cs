using Link_Backend_EF_Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Link_Backend_EF.Services.Base
{
    public class ExtrasService
    {
        public readonly IConfiguration _config;

        public ExtrasService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetToken(string AccessToken)
        {

            string keyV = _config["AES:Key"];
            string iv = _config["AES:AES_IV"];

            var DescAccessToken = AESEncDec.AESDecryption(AccessToken, keyV, iv);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, AccessToken),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            var res = new JwtSecurityTokenHandler().WriteToken(token);

            return res;
        }

        public async Task<string> EncryptToken(string AccessToken)
        {

            string keyV = _config["AES:Key"];
            string iv = _config["AES:AES_IV"];

            var EncryptAccessToken = AESEncDec.AESEncryption(AccessToken, keyV, iv);

            return EncryptAccessToken;
        }

        public async Task<string> DecryptToken(string AccessToken)
        {

            string keyV = _config["AES:Key"];
            string iv = _config["AES:AES_IV"];

            var EncryptAccessToken = AESEncDec.AESDecryption(AccessToken, keyV, iv);

            return EncryptAccessToken;
        }
    }
}
