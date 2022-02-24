using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvEducationService
    {
        Task<IDataResult<JobSeekerCvEducation>> GetAsync(int jobSeekerCvEducationId);
        Task<IDataResult<List<JobSeekerCvEducation>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCvEducation>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCvEducation>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvEducation jobSeekerCvEducation, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvEducation jobSeekerCvEducation, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvEducationId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvEducationId);
    }
}
