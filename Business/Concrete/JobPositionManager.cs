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
    public class JobPositionManager : IJobPositionService
    {
        private readonly IJobPositionDal _jobPositionDal;

        public JobPositionManager(IJobPositionDal jobPositionDal)
        {
            _jobPositionDal = jobPositionDal;
        }

        [ValidationAspect(typeof(JobPositionValidator))]
        [CacheRemoveAspect("IJobPositionService.Get")]
        public async Task<IResult> AddAsync(JobPosition jobPosition, string createdByName)
        {
            jobPosition.CreatedByName = createdByName;
            jobPosition.ModifiedByName = createdByName;
            await _jobPositionDal.AddAsync(jobPosition);
            return new SuccessResult(Messages.JobPosition.Add(jobPosition.Title));
        }

        public async Task<IResult> DeleteAsync(int jobPositionId, string modifiedByName)
        {
            var result = await _jobPositionDal.AnyAsync(j => j.Id == jobPositionId);
            if (result)
            {
                var jobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionId);
                jobPosition.IsActive = false;
                jobPosition.ModifiedByName = modifiedByName;
                jobPosition.ModifiedDate = DateTime.Now;
                await _jobPositionDal.UpdateAsync(jobPosition);
                return new SuccessResult(Messages.JobPosition.Delete(jobPosition.Title));
            }
            return new ErrorResult(Messages.JobPosition.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobPosition>>> GetAllAsync()
        {
            var jobPositions = await _jobPositionDal.GetAllAsync();
            if (jobPositions.Count > -1)
            {
                return new SuccessDataResult<List<JobPosition>>();
            }
            return new ErrorDataResult<List<JobPosition>>(Messages.JobPosition.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobPosition>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobPositions = await _jobPositionDal.GetAllAsync(j => !j.IsDeleted && j.IsActive);
            if (jobPositions.Count > -1)
            {
                return new SuccessDataResult<List<JobPosition>>();
            }
            return new ErrorDataResult<List<JobPosition>>(Messages.JobPosition.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobPosition>>> GetAllByNonDeletedAsync()
        {
            var jobPositions = await _jobPositionDal.GetAllAsync(j => !j.IsDeleted);
            if (jobPositions.Count > -1)
            {
                return new SuccessDataResult<List<JobPosition>>();
            }
            return new ErrorDataResult<List<JobPosition>>(Messages.JobPosition.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobPosition>> GetAsync(int jobPositionId)
        {
            var jobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionId);
            if (jobPosition != null)
            {
                return new SuccessDataResult<JobPosition>();
            }
            return new ErrorDataResult<JobPosition>();
        }

        public async Task<IResult> HardDeleteAsync(int jobPositionId)
        {
            var result = await _jobPositionDal.AnyAsync(j => j.Id == jobPositionId);
            if (result)
            {
                var jobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionId);
                await _jobPositionDal.DeleteAsync(jobPosition);
                return new SuccessResult(Messages.JobPosition.HardDelete(jobPosition.Title));
            }
            return new SuccessResult(Messages.JobPosition.NotFound(isPlural: false));
        }

        [ValidationAspect(typeof(JobPositionValidator))]
        [CacheRemoveAspect("IJobPositionService.Get")]
        public async Task<IResult> UpdateAsync(JobPosition jobPosition, string modifiedByName)
        {
            var oldJobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPosition.Id);
            oldJobPosition.ModifiedByName = modifiedByName;
            var updatedJobAdvert = await _jobPositionDal.UpdateAsync(oldJobPosition);
            return new SuccessResult(Messages.JobPosition.Update(updatedJobAdvert.Title));
        }
    }
}
