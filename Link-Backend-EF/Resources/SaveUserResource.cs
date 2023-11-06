using AutoMapper.Configuration.Annotations;
using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveUserResource
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string DeviceToken { get; set; }
    }
}
