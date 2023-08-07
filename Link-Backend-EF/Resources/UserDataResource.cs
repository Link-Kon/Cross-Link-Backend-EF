using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class UserDataResource
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        public int UserId { get; set; }
    }
}
