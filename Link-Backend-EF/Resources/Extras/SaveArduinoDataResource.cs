namespace Link_Backend_EF.Resources.Extras
{
    public class SaveArduinoDataResource
    {
        public decimal Red { get; set; }
        //public int InfraRed { get; set; }
        //public double AccelX { get; set; }
        //public double AccelY { get; set; }
        //public double AccelZ { get; set; }
        //public double RotX { get; set; }
        //public double RotY { get; set; }    
        //public double RotZ { get; set; }
    }

    public class SaveArduinoDataListResource
    {
        public List<SaveArduinoDataResource> Reds { get; set; }
        public string UserCode { get; set; }
    }
}
