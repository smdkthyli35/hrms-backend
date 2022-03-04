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
    public class WorkingTimeManager : IWorkingTimeService
    {
        private readonly IWorkingTimeDal _workingTimeDal;

        public WorkingTimeManager(IWorkingTimeDal workingTimeDal)
        {
            _workingTimeDal = workingTimeDal;
        }

        [SecuredOperation("workingtime.add,admin")]
        [ValidationAspect(typeof(WorkingTimeValidator))]
        [CacheRemoveAspect("IWorkingTimeService.Get")]
        public async Task<IResult> AddAsync(WorkingTime workingTime, string createdByName)
        {
            workingTime.CreatedByName = createdByName;
            workingTime.ModifiedByName = createdByName;
            await _workingTimeDal.AddAsync(workingTime);
            return new SuccessResult(Messages.WorkingTime.workingTimeAdded);
        }

        public async Task<IResult> DeleteAsync(int workingTimeId, string modifiedByName)
        {
            var result = await _workingTimeDal.AnyAsync(w => w.Id == workingTimeId);
            if (result)
            {
                var workingTime = await _workingTimeDal.GetAsync(w => w.Id == workingTimeId);
                workingTime.IsActive = false;
                workingTime.ModifiedByName = modifiedByName;
                workingTime.ModifiedDate = DateTime.Now;
                await _workingTimeDal.UpdateAsync(workingTime);
                return new SuccessResult(Messages.WorkingTime.workingTimeDeleted);
            }
            return new ErrorResult(Messages.WorkingTime.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<WorkingTime>>> GetAllAsync()
        {
            var workingTimes = await _workingTimeDal.GetAllAsync();
            if (workingTimes.Count > -1)
            {
                return new SuccessDataResult<List<WorkingTime>>();
            }
            return new ErrorDataResult<List<WorkingTime>>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<WorkingTime>>> GetAllByNonDeletedAndActiveAsync()
        {
            var workingTimes = await _workingTimeDal.GetAllAsync(w => !w.IsDeleted && w.IsActive);
            if (workingTimes.Count > -1)
            {
                return new SuccessDataResult<List<WorkingTime>>();
            }
            return new ErrorDataResult<List<WorkingTime>>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<WorkingTime>>> GetAllByNonDeletedAsync()
        {
            var workingTimes = await _workingTimeDal.GetAllAsync(w => !w.IsDeleted);
            if (workingTimes.Count > -1)
            {
                return new SuccessDataResult<List<WorkingTime>>();
            }
            return new ErrorDataResult<List<WorkingTime>>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTime>> GetAsync(int workingTimeId)
        {
            var workingTime = await _workingTimeDal.GetAsync(w => w.Id == workingTimeId);
            if (workingTime != null)
            {
                return new SuccessDataResult<WorkingTime>();
            }
            return new ErrorDataResult<WorkingTime>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        public async Task<IResult> HardDeleteAsync(int workingTimeId)
        {
            var result = await _workingTimeDal.AnyAsync(w => w.Id == workingTimeId);
            if (result)
            {
                var workingTime = await _workingTimeDal.GetAsync(w => w.Id == workingTimeId);
                await _workingTimeDal.DeleteAsync(workingTime);
                return new SuccessResult(Messages.WorkingTime.workingTimeHardDeleted);
            }
            return new SuccessResult(Messages.WorkingTime.NotFound(isPlural: false));
        }

        [SecuredOperation("workingtime.update,admin")]
        [ValidationAspect(typeof(WorkingTimeValidator))]
        [CacheRemoveAspect("IWorkingTimeService.Get")]
        public async Task<IResult> UpdateAsync(WorkingTime workingTime, string modifiedByName)
        {
            var oldWorkingTime = await _workingTimeDal.GetAsync(w => w.Id == workingTime.Id);
            oldWorkingTime.ModifiedByName = modifiedByName;
            var updatedWorkingTime = await _workingTimeDal.UpdateAsync(oldWorkingTime);
            return new SuccessResult(Messages.WorkingTime.workingTimeUpdated);
        }
    }
}
