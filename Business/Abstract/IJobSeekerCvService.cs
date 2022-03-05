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
    public interface IJobSeekerCvService
    {
        Task<IDataResult<JobSeekerCvDto>> GetAsync(int jobSeekerCvId);
        Task<IDataResult<JobSeekerCvListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvAddDto jobSeekerCvAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvUpdateDto jobSeekerCvUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvId);
    }
}
