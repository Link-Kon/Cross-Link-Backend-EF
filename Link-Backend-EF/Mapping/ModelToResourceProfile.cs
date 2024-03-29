﻿using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Resources;

namespace Link_Backend_EF.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<FallRecord, FallRecordResource>();
            CreateMap<Friendship, FriendshipResource>();
            CreateMap<HeartIssuesRecord, HeartIssuesRecordResource>();
            CreateMap<HeartRhythmRecord, HeartRhythmRecordResource>();
            CreateMap<Illness, IllnessResource>();
            CreateMap<Patient, PatientResource>();
            CreateMap<User, UserResource>();
            CreateMap<UserData, UserDataResource>();
        }
    }
}
