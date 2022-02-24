using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobSeekerCvSkillService
    {
        Task<IDataResult<JobSeekerCvSkill>> GetAsync(int jobSeekerCvSkillId);
        Task<IDataResult<List<JobSeekerCvSkill>>> GetAllAsync();
        Task<IDataResult<List<JobSeekerCvSkill>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobSeekerCvSkill>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobSeekerCvSkill jobSeekerCvSkill, string createdByName);
        Task<IResult> UpdateAsync(JobSeekerCvSkill jobSeekerCvSkill, string modifiedByName);
        Task<IResult> DeleteAsync(int jobSeekerCvSkillId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobSeekerCvSkillId);
    }
}
