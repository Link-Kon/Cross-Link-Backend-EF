using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class UpdateUserResource
    {
        //[Required]
        //public string Token { get; set; }
        [Required]
        public string DeviceToken { get; set; }
        //[Required]
        //public string Code { get; set; }
    }
}
