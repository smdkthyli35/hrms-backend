using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Profiles
{
    public class CompanyStaffProfile : Profile
    {
        public CompanyStaffProfile()
        {
            CreateMap<CompanyStaffAddDto, CompanyStaff>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ReverseMap();

            CreateMap<CompanyStaffUpdateDto, CompanyStaff>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.User.Id)).ReverseMap();
        }
    }
}
