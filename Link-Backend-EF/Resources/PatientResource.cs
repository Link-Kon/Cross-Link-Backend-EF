﻿namespace Link_Backend_EF.Resources
{
    public class PatientResource
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Country { get; set; }
        public int UserDataId { get; set; }
    }
}
