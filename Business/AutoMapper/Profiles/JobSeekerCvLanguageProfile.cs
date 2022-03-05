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
    public class JobSeekerCvLanguageProfile : Profile
    {
        public JobSeekerCvLanguageProfile()
        {
            CreateMap<JobSeekerCvLanguageAddDto, JobSeekerCvLanguage>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(x => x.Language.Id))
                .ReverseMap();

            CreateMap<JobSeekerCvLanguageUpdateDto, JobSeekerCvLanguage>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.JobSeekerCvId, opt => opt.MapFrom(x => x.JobSeekerCv.Id))
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(x => x.Language.Id))
                .ReverseMap();
        }
    }
}
