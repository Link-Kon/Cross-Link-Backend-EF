using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Resources
{
    public class UserPublicResource
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
    }
}
