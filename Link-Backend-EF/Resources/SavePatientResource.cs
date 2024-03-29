﻿using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SavePatientResource
    {
        [Required]
        public bool Active { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int UserDataId { get; set; }
    }
}
