﻿using Link_Backend_EF.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveIllnessesListResource : DateAuditory
    {
        [Required]
        public int UserDataId { get; set; }
        [Required]
        public int IllnessId { get; set; }
        [Required]
        public bool State { get; set; }

        public SaveIllnessesListResource(DateTime creationDate) : base(creationDate)
        {
        }
    }
}