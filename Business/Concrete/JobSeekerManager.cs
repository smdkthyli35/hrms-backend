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
    public class JobSeekerManager : IJobSeekerService
    {
        private readonly IJobSeekerDal _jobSeekerDal;

        public JobSeekerManager(IJobSeekerDal jobSeekerDal)
        {
            _jobSeekerDal = jobSeekerDal;
        }

        [SecuredOperation("jobseeker.add,admin")]
        [ValidationAspect(typeof(JobSeekerValidator))]
        [CacheRemoveAspect("IJobSeekerService.Get")]
        public async Task<IResult> AddAsync(JobSeeker jobSeeker, string createdByName)
        {
            jobSeeker.CreatedByName = createdByName;
            jobSeeker.ModifiedByName = createdByName;
            await _jobSeekerDal.AddAsync(jobSeeker);
            return new SuccessResult(Messages.JobSeeker.Add(jobSeeker.FirstName, jobSeeker.LastName));
        }

        public async Task<IResult> DeleteAsync(int jobSeekerId, string modifiedByName)
        {
            var result = await _jobSeekerDal.AnyAsync(j => j.Id == jobSeekerId);
            if (result)
            {
                var jobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerId);
                jobSeeker.IsActive = false;
                jobSeeker.ModifiedByName = modifiedByName;
                jobSeeker.ModifiedDate = DateTime.Now;
                await _jobSeekerDal.UpdateAsync(jobSeeker);
                return new SuccessResult(Messages.JobSeeker.Delete(jobSeeker.FirstName, jobSeeker.LastName));
            }
            return new ErrorResult(Messages.JobSeeker.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeeker>>> GetAllAsync()
        {
            var jobSeekers = await _jobSeekerDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekers.Count > -1)
            {
                return new SuccessDataResult<List<JobSeeker>>();
            }
            return new ErrorDataResult<List<JobSeeker>>(Messages.JobSeeker.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeeker>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekers = await _jobSeekerDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv);
            if (jobSeekers.Count > -1)
            {
                return new SuccessDataResult<List<JobSeeker>>();
            }
            return new ErrorDataResult<List<JobSeeker>>(Messages.JobSeeker.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeeker>>> GetAllByNonDeletedAsync()
        {
            var jobSeekers = await _jobSeekerDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv);
            if (jobSeekers.Count > -1)
            {
                return new SuccessDataResult<List<JobSeeker>>();
            }
            return new ErrorDataResult<List<JobSeeker>>(Messages.JobSeeker.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeeker>> GetAsync(int jobSeekerId)
        {
            var jobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerId, j => j.JobSeekerCv);
            if (jobSeeker != null)
            {
                return new SuccessDataResult<JobSeeker>();
            }
            return new ErrorDataResult<JobSeeker>();
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerId)
        {
            var result = await _jobSeekerDal.AnyAsync(j => j.Id == jobSeekerId);
            if (result)
            {
                var jobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerId);
                await _jobSeekerDal.DeleteAsync(jobSeeker);
                return new SuccessResult(Messages.JobSeeker.HardDelete(jobSeeker.FirstName, jobSeeker.LastName));
            }
            return new SuccessResult(Messages.JobSeeker.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseeker.update,admin")]
        [ValidationAspect(typeof(JobSeekerValidator))]
        [CacheRemoveAspect("IJobSeekerService.Get")]
        public async Task<IResult> UpdateAsync(JobSeeker jobSeeker, string modifiedByName)
        {
            var oldjobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeeker.Id);
            oldjobSeeker.ModifiedByName = modifiedByName;
            var updatedJobSeeker = await _jobSeekerDal.UpdateAsync(oldjobSeeker);
            return new SuccessResult(Messages.JobSeeker.Update(updatedJobSeeker.FirstName, updatedJobSeeker.LastName));
        }
    }
}
