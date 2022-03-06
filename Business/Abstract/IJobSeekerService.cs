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
    public interface IJobSeekerService
    {
        Task<IDataResult<JobSeekerDto>> GetAsync(int jobSeekerId);
        Task<IDataResult<JobSeekerDto>> GetByIdentityNumberAsync(string identityNumber);
        Task<IDataResult<JobSeekerListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerAddDto jobSeekerAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerUpdateDto jobSeekerUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerId);
    }
}
