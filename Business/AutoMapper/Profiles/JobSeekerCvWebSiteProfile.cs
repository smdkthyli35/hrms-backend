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
    public class JobSeekerCvWebSiteProfile : Profile
    {
        public JobSeekerCvWebSiteProfile()
        {
            CreateMap<JobSeekerCvWebSiteAddDto, JobSeekerCvWebSite>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.WebSiteId, opt => opt.MapFrom(x => x.WebSite.Id))
                .ReverseMap();

            CreateMap<JobSeekerCvWebSiteUpdateDto, JobSeekerCvWebSite>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.WebSiteId, opt => opt.MapFrom(x => x.WebSite.Id))
                .ReverseMap();
        }
    }
}
