namespace Link_Backend_EF.Resources.Base
{
    public class SaveTokenValidationResource
    {
        public int Id { get; set; }
        public string OldToken { get; set; }
        public string NewToken { get; set; }
    }
}
