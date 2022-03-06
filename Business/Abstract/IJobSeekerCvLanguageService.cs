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
    public interface IJobSeekerCvLanguageService
    {
        Task<IDataResult<JobSeekerCvLanguageDto>> GetAsync(int jobSeekerCvLanguageId);
        Task<IDataResult<JobSeekerCvLanguageListDto>> GetListByJobSeekerCvAsync(int jobSeekerCvId);
        Task<IDataResult<JobSeekerCvLanguageListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvLanguageListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvLanguageListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvLanguageAddDto jobSeekerCvLanguageAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvLanguageUpdateDto jobSeekerCvLanguageUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvLanguageId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvLanguageId);
    }
}
