using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF_Security;
using Link_Backend_Google_Services.PushNotifications;
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
        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;

        public ExtrasService(IConfiguration config, IUserRepository userRepository, IFriendshipRepository friendshipRepository)
        {
            _config = config;
            _userRepository = userRepository;
            _friendshipRepository = friendshipRepository;
        }

        public async Task<string> GetToken(string AccessToken)
        {

            string keyV = _config["AES:Key"];
            string iv = _config["AES:AES_IV"];

            var DescAccessToken = AESEncDec.AESDecryption(AccessToken, keyV, iv);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, DescAccessToken),
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

        public async Task<List<TokenDevice>> GetDevicesToken(string userCode)
        {
            List<TokenDevice> tokenDevices= new List<TokenDevice>();

            IEnumerable<Friendship> friendList =  await _friendshipRepository.ListByUserCodeAsync(userCode);

            foreach (Friendship friendship in friendList)
            {
                if (friendship.User1Code != userCode)
                {
                    tokenDevices.Add(new TokenDevice
                    {
                        DeviceToken = friendship.User1Code
                    });
                }
                else
                {
                    tokenDevices.Add(new TokenDevice
                    {
                        DeviceToken = friendship.User2Code
                    });
                }
            }

            return tokenDevices;
        }
    }
}
