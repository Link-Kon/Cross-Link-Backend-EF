﻿namespace Link_Backend_EF.Domain.Models
{
    public class FallRecord
    {
        public int Id { get; set; }
        public string LectureDate { get; set; }
        public string Severity { get; set; }
        public int UserDataId { get; set; }
    }
}
