using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvService
    {
        Task<IDataResult<JobSeekerCv>> GetAsync(int jobSeekerCvId);
        Task<IDataResult<List<JobSeekerCv>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCv>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCv>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCv jobSeekerCv, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCv jobSeekerCv, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvId);
    }
}
