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
    public class JobSeekerProfile : Profile
    {
        public JobSeekerProfile()
        {
            CreateMap<JobSeekerAddDto, JobSeeker>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.User.Id))
                .ReverseMap();

            CreateMap<JobSeekerUpdateDto, JobSeeker>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x => x.User.Id))
                .ReverseMap();
        }
    }
}
