namespace Link_Backend_EF.Resources.Extras
{
    public class SaveArduinoGyroDataResource
    {
        public double AccelX { get; set; }
        public double AccelY { get; set; }
        public double AccelZ { get; set; }
        public double RotX { get; set; }
        public double RotY { get; set; }
        public double RotZ { get; set; }
    }

    public class SaveArduinoGyroDataListResource
    {
        public List<SaveArduinoHeartDataResource> Gyros { get; set; }
        public string UserCode { get; set; }
    }
}
