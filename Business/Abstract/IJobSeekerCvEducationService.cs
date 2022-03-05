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
    public interface IJobSeekerCvEducationService
    {
        Task<IDataResult<JobSeekerCvEducationDto>> GetAsync(int jobSeekerCvEducationId);
        Task<IDataResult<JobSeekerCvEducationListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvEducationListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvEducationListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvEducationAddDto jobSeekerCvEducationAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvEducationUpdateDto jobSeekerCvEducationUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvEducationId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvEducationId);
    }
}
