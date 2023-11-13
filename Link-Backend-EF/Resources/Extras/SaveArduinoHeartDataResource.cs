namespace Link_Backend_EF.Resources.Extras
{
    public class SaveArduinoHeartDataResource
    {
        public decimal Red { get; set; }
        //public int InfraRed { get; set; }
    }

    public class SaveArduinoHeartDataListResource
    {
        public List<SaveArduinoHeartDataResource> Reds { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
    }
}
