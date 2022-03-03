using Business.Abstract;
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
    public class JobSeekerCvExperienceManager : IJobSeekerCvExperienceService
    {
        private readonly IJobSeekerCvExperienceDal _jobSeekerCvExperienceDal;

        public JobSeekerCvExperienceManager(IJobSeekerCvExperienceDal jobSeekerCvExperienceDal)
        {
            _jobSeekerCvExperienceDal = jobSeekerCvExperienceDal;
        }

        [ValidationAspect(typeof(JobSeekerCvExperienceValidator))]
        [CacheRemoveAspect("IJobSeekerCvExperienceService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvExperience jobSeekerCvExperience, string createdByName)
        {
            jobSeekerCvExperience.CreatedByName = createdByName;
            jobSeekerCvExperience.ModifiedByName = createdByName;
            await _jobSeekerCvExperienceDal.AddAsync(jobSeekerCvExperience);
            return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvExperienceId, string modifiedByName)
        {
            var result = await _jobSeekerCvExperienceDal.AnyAsync(j => j.Id == jobSeekerCvExperienceId);
            if (result)
            {
                var jobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceId);
                jobSeekerCvExperience.IsActive = false;
                jobSeekerCvExperience.ModifiedByName = modifiedByName;
                jobSeekerCvExperience.ModifiedDate = DateTime.Now;
                await _jobSeekerCvExperienceDal.UpdateAsync(jobSeekerCvExperience);
                return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvExperience.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvExperience>>> GetAllAsync()
        {
            var jobSeekerCvExperiences = await _jobSeekerCvExperienceDal.GetAllAsync(null, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperiences.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvExperience>>();
            }
            return new ErrorDataResult<List<JobSeekerCvExperience>>(Messages.JobSeekerCvExperience.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvExperience>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvExperiences = await _jobSeekerCvExperienceDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperiences.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvExperience>>();
            }
            return new ErrorDataResult<List<JobSeekerCvExperience>>(Messages.JobSeekerCvExperience.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvExperience>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvExperiences = await _jobSeekerCvExperienceDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperiences.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvExperience>>();
            }
            return new ErrorDataResult<List<JobSeekerCvExperience>>(Messages.JobSeekerCvExperience.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvExperience>> GetAsync(int jobSeekerCvExperienceId)
        {
            var jobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceId, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperience != null)
            {
                return new SuccessDataResult<JobSeekerCvExperience>();
            }
            return new ErrorDataResult<JobSeekerCvExperience>();
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvExperienceId)
        {
            var result = await _jobSeekerCvExperienceDal.AnyAsync(j => j.Id == jobSeekerCvExperienceId);
            if (result)
            {
                var jobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceId);
                await _jobSeekerCvExperienceDal.DeleteAsync(jobSeekerCvExperience);
                return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvExperience.NotFound(isPlural: false));
        }

        [ValidationAspect(typeof(JobSeekerCvExperienceValidator))]
        [CacheRemoveAspect("IJobSeekerCvExperienceService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvExperience jobSeekerCvExperience, string modifiedByName)
        {
            var oldjobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperience.Id);
            oldjobSeekerCvExperience.ModifiedByName = modifiedByName;
            var updatedJobSeekerCvExperience = await _jobSeekerCvExperienceDal.UpdateAsync(oldjobSeekerCvExperience);
            return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceUpdated);
        }
    }
}
