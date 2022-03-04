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
    public class JobAdvertManager : IJobAdvertService
    {
        private readonly IJobAdvertDal _jobAdvertDal;

        public JobAdvertManager(IJobAdvertDal jobAdvertDal)
        {
            _jobAdvertDal = jobAdvertDal;
        }

        [SecuredOperation("jobadvert.add,admin")]
        [ValidationAspect(typeof(JobAdvertValidator))]
        [CacheRemoveAspect("IJobAdvertService.Get")]
        public async Task<IResult> AddAsync(JobAdvert jobAdvert, string createdByName)
        {
            jobAdvert.CreatedByName = createdByName;
            jobAdvert.ModifiedByName = createdByName;
            await _jobAdvertDal.AddAsync(jobAdvert);
            return new SuccessResult(Messages.JobAdvert.jobAdvertAdded);
        }

        public async Task<IResult> DeleteAsync(int jobAdvertId, string modifiedByName)
        {
            var result = await _jobAdvertDal.AnyAsync(j => j.Id == jobAdvertId);
            if (result)
            {
                var jobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertId);
                jobAdvert.IsActive = false;
                jobAdvert.ModifiedByName = modifiedByName;
                jobAdvert.ModifiedDate = DateTime.Now;
                await _jobAdvertDal.UpdateAsync(jobAdvert);
                return new SuccessResult(Messages.JobAdvert.jobAdvertDeleted);
            }
            return new ErrorResult(Messages.JobAdvert.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobAdvert>>> GetAllAsync()
        {
            var jobAdverts = await _jobAdvertDal.GetAllAsync(null, j => j.City, j => j.Employer, j => j.JobPosition, j => j.WorkingTime, j => j.WorkingType);
            if (jobAdverts.Count > -1)
            {
                return new SuccessDataResult<List<JobAdvert>>();
            }
            return new ErrorDataResult<List<JobAdvert>>(Messages.JobAdvert.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobAdvert>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobAdverts = await _jobAdvertDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.City, j => j.Employer, j => j.JobPosition, j => j.WorkingTime, j => j.WorkingType);
            if (jobAdverts.Count > -1)
            {
                return new SuccessDataResult<List<JobAdvert>>();
            }
            return new ErrorDataResult<List<JobAdvert>>(Messages.JobAdvert.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobAdvert>>> GetAllByNonDeletedAsync()
        {
            var jobAdverts = await _jobAdvertDal.GetAllAsync(j => !j.IsDeleted, j => j.City, j => j.Employer, j => j.JobPosition, j => j.WorkingTime, j => j.WorkingType);
            if (jobAdverts.Count > -1)
            {
                return new SuccessDataResult<List<JobAdvert>>();
            }
            return new ErrorDataResult<List<JobAdvert>>(Messages.JobAdvert.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobAdvert>> GetAsync(int jobAdvertId)
        {
            var jobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertId);
            if (jobAdvert != null)
            {
                return new SuccessDataResult<JobAdvert>();
            }
            return new ErrorDataResult<JobAdvert>();
        }

        public async Task<IResult> HardDeleteAsync(int jobAdvertId)
        {
            var result = await _jobAdvertDal.AnyAsync(j => j.Id == jobAdvertId);
            if (result)
            {
                var jobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertId);
                await _jobAdvertDal.DeleteAsync(jobAdvert);
                return new SuccessResult(Messages.JobAdvert.jobAdvertHardDeleted);
            }
            return new SuccessResult(Messages.JobAdvert.NotFound(isPlural: false));
        }

        [SecuredOperation("jobadvert.update,admin")]
        [ValidationAspect(typeof(JobAdvertValidator))]
        [CacheRemoveAspect("IJobAdvertService.Get")]
        public async Task<IResult> UpdateAsync(JobAdvert jobAdvert, string modifiedByName)
        {
            var oldJobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvert.Id);
            oldJobAdvert.ModifiedByName = modifiedByName;
            var updatedJobAdvert = await _jobAdvertDal.UpdateAsync(oldJobAdvert);
            return new SuccessResult(Messages.JobAdvert.jobAdvertUpdated);
        }
    }
}
