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
    public class JobSeekerCvExperienceProfile : Profile
    {
        public JobSeekerCvExperienceProfile()
        {
            CreateMap<JobSeekerCvExperienceAddDto, JobSeekerCvExperience>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.JobPositionId, opt => opt.MapFrom(x => x.JobPosition.Id))
                .ReverseMap();

            CreateMap<JobSeekerCvExperienceUpdateDto, JobSeekerCvExperience>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.JobPositionId, opt => opt.MapFrom(x => x.JobPosition.Id))
                .ReverseMap();
        }
    }
}
