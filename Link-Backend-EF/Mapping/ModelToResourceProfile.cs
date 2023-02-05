using AutoMapper;
using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Resources;

namespace Link_Backend_EF.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Illness, IllnessResource>();
        }
    }
}
