using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvLanguageService
    {
        Task<IDataResult<JobSeekerCvLanguage>> GetAsync(int jobSeekerCvLanguageId);
        Task<IDataResult<List<JobSeekerCvLanguage>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCvLanguage>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCvLanguage>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvLanguage jobSeekerCvLanguage, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvLanguage jobSeekerCvLanguage, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvLanguageId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvLanguageId);
    }
}
