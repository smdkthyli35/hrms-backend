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
    public class JobAdvertProfile : Profile
    {
        public JobAdvertProfile()
        {
            CreateMap<JobAdvertAddDto, JobAdvert>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(x => x.City.Id))
                .ForMember(dest => dest.EmployerId, opt => opt.MapFrom(x => x.Employer.Id))
                .ForMember(dest => dest.JobPositionId, opt => opt.MapFrom(x => x.JobPosition.Id))
                .ForMember(dest => dest.WorkingTimeId, opt => opt.MapFrom(x => x.WorkingTime.Id))
                .ForMember(dest => dest.WorkingTypeId, opt => opt.MapFrom(x => x.WorkingType.Id))
                .ReverseMap();

            CreateMap<JobAdvertUpdateDto, JobAdvert>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(x => x.City.Id))
                .ForMember(dest => dest.EmployerId, opt => opt.MapFrom(x => x.Employer.Id))
                .ForMember(dest => dest.JobPositionId, opt => opt.MapFrom(x => x.JobPosition.Id))
                .ForMember(dest => dest.WorkingTimeId, opt => opt.MapFrom(x => x.WorkingTime.Id))
                .ForMember(dest => dest.WorkingTypeId, opt => opt.MapFrom(x => x.WorkingType.Id))
                .ReverseMap();
        }
    }
}
