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
    public interface IJobSeekerCvWebSiteService
    {
        Task<IDataResult<JobSeekerCvWebSiteDto>> GetAsync(int jobSeekerCvWebSiteId);
        Task<IDataResult<JobSeekerCvWebSiteListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvWebSiteListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvWebSiteListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvWebSiteAddDto jobSeekerCvWebSiteAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvWebSiteUpdateDto jobSeekerCvWebSiteUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvWebSiteId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvWebSiteId);
    }
}
