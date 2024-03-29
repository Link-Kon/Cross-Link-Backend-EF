﻿using System.ComponentModel.DataAnnotations;

namespace Link_Backend_EF.Resources
{
    public class SaveHeartRhythmRecordResource
    {
        [Required]
        public DateTime LectureDate { get; set; }
        [Required]
        public int Bpm { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
