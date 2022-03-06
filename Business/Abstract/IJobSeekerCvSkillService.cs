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
    public interface IJobSeekerCvSkillService
    {
        Task<IDataResult<JobSeekerCvSkillDto>> GetAsync(int jobSeekerCvSkillId);
        Task<IDataResult<JobSeekerCvSkillListDto>> GetListByJobSeekerCvAsync(int jobSeekerCvId);
        Task<IDataResult<JobSeekerCvSkillListDto>> GetAllAsync();
        Task<IDataResult<JobSeekerCvSkillListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobSeekerCvSkillListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvSkillAddDto jobSeekerCvSkillAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvSkillUpdateDto jobSeekerCvSkillUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvSkillId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvSkillId);
    }
}
