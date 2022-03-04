using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobSeekerCvSkillManager : IJobSeekerCvSkillService
    {
        private readonly IJobSeekerCvSkillDal _jobSeekerCvSkillDal;

        public JobSeekerCvSkillManager(IJobSeekerCvSkillDal jobSeekerCvSkillDal)
        {
            _jobSeekerCvSkillDal = jobSeekerCvSkillDal;
        }

        [SecuredOperation("jobseekercvskill.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvSkillValidator))]
        [CacheRemoveAspect("IJobSeekerCvSkillService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvSkill jobSeekerCvSkill, string createdByName)
        {
            jobSeekerCvSkill.CreatedByName = createdByName;
            jobSeekerCvSkill.ModifiedByName = createdByName;
            await _jobSeekerCvSkillDal.AddAsync(jobSeekerCvSkill);
            return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvSkillId, string modifiedByName)
        {
            var result = await _jobSeekerCvSkillDal.AnyAsync(j => j.Id == jobSeekerCvSkillId);
            if (result)
            {
                var jobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillId);
                jobSeekerCvSkill.IsActive = false;
                jobSeekerCvSkill.ModifiedByName = modifiedByName;
                jobSeekerCvSkill.ModifiedDate = DateTime.Now;
                await _jobSeekerCvSkillDal.UpdateAsync(jobSeekerCvSkill);
                return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvSkill.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvSkill>>> GetAllAsync()
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvSkill>>();
            }
            return new ErrorDataResult<List<JobSeekerCvSkill>>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvSkill>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvSkill>>();
            }
            return new ErrorDataResult<List<JobSeekerCvSkill>>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvSkill>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvSkill>>();
            }
            return new ErrorDataResult<List<JobSeekerCvSkill>>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvSkill>> GetAsync(int jobSeekerCvSkillId)
        {
            var jobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillId, j => j.JobSeekerCv);
            if (jobSeekerCvSkill != null)
            {
                return new SuccessDataResult<JobSeekerCvSkill>();
            }
            return new ErrorDataResult<JobSeekerCvSkill>();
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvSkillId)
        {
            var result = await _jobSeekerCvSkillDal.AnyAsync(j => j.Id == jobSeekerCvSkillId);
            if (result)
            {
                var jobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillId);
                await _jobSeekerCvSkillDal.DeleteAsync(jobSeekerCvSkill);
                return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvSkill.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercvskill.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvSkillValidator))]
        [CacheRemoveAspect("IJobSeekerCvSkillService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvSkill jobSeekerCvSkill, string modifiedByName)
        {
            var oldjobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkill.Id);
            oldjobSeekerCvSkill.ModifiedByName = modifiedByName;
            var updatedJobSeekerCvSkill = await _jobSeekerCvSkillDal.UpdateAsync(oldjobSeekerCvSkill);
            return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillUpdated);
        }
    }
}
