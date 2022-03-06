using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvExperienceService
    {
        Task<IDataResult<JobSeekerCvExperienceDto>> GetAsync(int jobSeekerCvExperienceId);
        Task<IDataResult<JobSeekerCvExperienceListDto>> GetListByJobSeekerCvAsync(int jobSeekerCvId);
        Task<IDataResult<JobSeekerCvExperienceListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvExperienceListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvExperienceListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvExperienceAddDto jobSeekerCvExperienceAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvExperienceUpdateDto jobSeekerCvExperienceUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvExperienceId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvExperienceId);
    }
}
