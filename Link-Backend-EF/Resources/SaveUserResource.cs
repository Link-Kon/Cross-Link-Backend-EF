using AutoMapper.Configuration.Annotations;
using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveUserResource : DateAuditory
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Token { get; set; }

        public SaveUserResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
