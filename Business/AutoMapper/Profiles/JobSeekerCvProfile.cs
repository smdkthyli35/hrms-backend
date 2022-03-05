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
    public class JobSeekerCvProfile : Profile
    {
        public JobSeekerCvProfile()
        {
            CreateMap<JobSeekerCvAddDto, JobSeekerCv>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerId, opt => opt.MapFrom(x => x.JobSeeker.Id))
                .ReverseMap();

            CreateMap<JobSeekerCvUpdateDto, JobSeekerCv>()
               .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
               .ForMember(dest => dest.JobSeekerId, opt => opt.MapFrom(x => x.JobSeeker.Id))
               .ReverseMap();
        }
    }
}
