using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Resources;
using Link_Backend_EF.Resources.Base;
using Microsoft.OpenApi.Any;

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
            CreateMap<IllnessesList, IllnessesListResource>();
            CreateMap<Patient, PatientResource>();
            CreateMap<User, UserResource>();
            CreateMap<UserData, UserDataResource>();

            CreateMap<UserDevice, UserDeviceResource>();
            CreateMap<Device, DeviceResource>();

            //Validation Resource
            CreateMap(typeof(BaseResponse<>), typeof(ValidationResource));
            CreateMap(typeof(BaseResponse<List<UserDevice>>), typeof(UserDeviceResource));
            CreateMap(typeof(BaseResponse<List<IllnessesList>>), typeof(IllnessesListResource));

        }
    }
}
