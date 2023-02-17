using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Resources;

namespace Link_Backend_EF.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveFallRecordResource, FallRecord>();
            CreateMap<SaveFriendshipResource, Friendship>();
            CreateMap<SaveHeartIssuesRecordResource, HeartIssuesRecord>();
            CreateMap<SaveHeartRhythmRecordResource, HeartRhythmRecord>();
            CreateMap<SaveIllnessResource, Illness>();
            CreateMap<SavePatientResource, Patient>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveUserDataResource, UserData>();
        }
    }
}
