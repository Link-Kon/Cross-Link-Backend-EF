﻿using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveUserDeviceResource : DateAuditory
    {
        [Required]
        public int UserDataId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        [Required]
        public bool State { get; set; }

        public SaveUserDeviceResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}
