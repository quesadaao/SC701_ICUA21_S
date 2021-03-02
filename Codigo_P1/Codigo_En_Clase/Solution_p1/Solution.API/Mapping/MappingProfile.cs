using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = Solution.DO.Objects;

namespace Solution.API.Mapping
{
    public class MappingProfile:Profile
    {
        // Necesitamos crear el metodo para direccionar los casteos de objetos

        public MappingProfile() {
            CreateMap<data.Foci, DataModels.Foci>().ReverseMap();
            CreateMap<data.Groups, DataModels.Groups>().ReverseMap();
            CreateMap<data.GroupInvitations, DataModels.GroupInvitations>().ReverseMap();
            CreateMap<data.GroupRequests, DataModels.GroupRequests>().ReverseMap();

            CreateMap<data.GroupComments, DataModels.GroupComments>().ReverseMap();
            CreateMap<data.GroupUpdates, DataModels.GroupUpdates>().ReverseMap();
            CreateMap<data.GroupUpdateSupports, DataModels.GroupUpdateSupports>().ReverseMap();
        }
    }
}
