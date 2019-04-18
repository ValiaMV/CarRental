using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Business.Models.Car, Data.Models.Car>().ReverseMap();
            CreateMap<Business.Models.User, Data.Models.User>().ReverseMap();
        }
    }
}
