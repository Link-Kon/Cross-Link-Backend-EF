﻿namespace Link_Backend_EF.Domain.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Country { get; set; }
        public int UserDataId { get; set; }

        public UserData UserData { get; set; }
        public List<FallRecord> FallRecords { get; set; }
        public List<HeartIssuesRecord> HeartIssuesRecords { get; set; }
        public List<HeartRhythmRecord> HeartRhythmRecords { get; set; }
    }
}
