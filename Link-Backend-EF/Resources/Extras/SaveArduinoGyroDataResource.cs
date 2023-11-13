namespace Link_Backend_EF.Resources.Extras
{
    public class SaveArduinoGyroDataResource
    {
        public decimal AccelX { get; set; }
        public decimal AccelY { get; set; }
        public decimal AccelZ { get; set; }
        public decimal RotX { get; set; }
        public decimal RotY { get; set; }
        public decimal RotZ { get; set; }
    }

    public class SaveArduinoGyroDataListResource
    {
        public List<SaveArduinoGyroDataResource> Gyros { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
    }
}
