using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvExperienceService
    {
        Task<IDataResult<JobSeekerCvExperience>> GetAsync(int jobSeekerCvExperienceId);
        Task<IDataResult<List<JobSeekerCvExperience>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCvExperience>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCvExperience>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvExperience jobSeekerCvExperience, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvExperience jobSeekerCvExperience, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvExperienceId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvExperienceId);
    }
}
