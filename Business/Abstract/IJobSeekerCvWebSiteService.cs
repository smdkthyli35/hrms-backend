using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvWebSiteService
    {
        Task<IDataResult<JobSeekerCvWebSite>> GetAsync(int jobSeekerCvWebSiteId);
        Task<IDataResult<List<JobSeekerCvWebSite>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCvWebSite>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCvWebSite>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvWebSite jobSeekerCvWebSite, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvWebSite jobSeekerCvWebSite, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvWebSiteId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvWebSiteId);
    }
}
