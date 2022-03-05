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
    public class JobSeekerCvEducationProfile : Profile
    {
        public JobSeekerCvEducationProfile()
        {
            CreateMap<JobSeekerCvEducationAddDto, JobSeekerCvEducation>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ReverseMap();

            CreateMap<JobSeekerCvEducationUpdateDto, JobSeekerCvEducation>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ReverseMap();
        }
    }
}
