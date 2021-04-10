using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Customers, DataModels.Customer>().ReverseMap();
            CreateMap<data.Orders, DataModels.Orders>().ReverseMap();
            CreateMap<data.Staffs, DataModels.Staffs>().ReverseMap();
            CreateMap<data.Stores, DataModels.Stores>().ReverseMap();

        }
    }
}
