﻿using Link_Backend_EF.Domain.Models.Base;

namespace Link_Backend_EF.Resources
{
    public class SaveDeviceResource : DateAuditory
    {
        public string Nickname { get; set; }
        public string MacAddress { get; set; }
        public string Model { get; set; }
        public decimal Version { get; set; }
        public SaveDeviceResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
