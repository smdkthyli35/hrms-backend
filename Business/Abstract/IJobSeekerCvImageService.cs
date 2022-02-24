using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvImageService
    {
        Task<IDataResult<JobSeekerCvImage>> GetAsync(int jobSeekerCvImageId);
        Task<IDataResult<List<JobSeekerCvImage>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCvImage>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCvImage>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvImage jobSeekerCvImage, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvImage jobSeekerCvImage, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvImageId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvImageId);
    }
}
