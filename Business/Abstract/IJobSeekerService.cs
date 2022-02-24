using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerService
    {
        Task<IDataResult<JobSeeker>> GetAsync(int jobSeekerId);
        Task<IDataResult<List<JobSeeker>>> GetAllAsync();
        Task<IDataResult<List<JobSeeker>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeeker>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeeker jobSeeker, string createdByName);
        Task<IResult> UpdateAsync(JobSeeker jobSeeker, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerId);
    }
}
