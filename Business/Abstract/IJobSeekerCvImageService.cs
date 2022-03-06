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
    public interface IJobSeekerCvImageService
    {
        Task<IDataResult<JobSeekerCvImageDto>> GetAsync(int jobSeekerCvImageId);
        Task<IDataResult<JobSeekerCvImageListDto>> GetListByJobSeekerCvAsync(int jobSeekerCvId);
        Task<IDataResult<JobSeekerCvImageListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvImageListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvImageListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvImageAddDto jobSeekerCvImageAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvImageUpdateDto jobSeekerCvImageUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvImageId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvImageId);
    }
}
