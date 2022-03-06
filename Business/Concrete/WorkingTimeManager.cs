using AutoMapper;
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
using Entities.Dtos;
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
        private readonly IMapper _mapper;

        public WorkingTimeManager(IWorkingTimeDal workingTimeDal, IMapper mapper)
        {
            _workingTimeDal = workingTimeDal;
            _mapper = mapper;
        }

        [SecuredOperation("workingtime.add,admin")]
        [ValidationAspect(typeof(WorkingTimeValidator))]
        [CacheRemoveAspect("IWorkingTimeService.Get")]
        public async Task<IResult> AddAsync(WorkingTimeAddDto workingTimeAddDto, string createdByName)
        {
            var workingTime = _mapper.Map<WorkingTime>(workingTimeAddDto);
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
        public async Task<IDataResult<WorkingTimeListDto>> GetAllAsync()
        {
            var workingTimes = await _workingTimeDal.GetAllAsync();
            if (workingTimes.Count > -1)
            {
                return new SuccessDataResult<WorkingTimeListDto>(new WorkingTimeListDto
                {
                    WorkingTimes = workingTimes
                });
            }
            return new ErrorDataResult<WorkingTimeListDto>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTimeListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var workingTimes = await _workingTimeDal.GetAllAsync(w => !w.IsDeleted && w.IsActive);
            if (workingTimes.Count > -1)
            {
                return new SuccessDataResult<WorkingTimeListDto>(new WorkingTimeListDto
                {
                    WorkingTimes = workingTimes
                });
            }
            return new ErrorDataResult<WorkingTimeListDto>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTimeListDto>> GetAllByNonDeletedAsync()
        {
            var workingTimes = await _workingTimeDal.GetAllAsync(w => !w.IsDeleted);
            if (workingTimes.Count > -1)
            {
                return new SuccessDataResult<WorkingTimeListDto>(new WorkingTimeListDto
                {
                    WorkingTimes = workingTimes
                });
            }
            return new ErrorDataResult<WorkingTimeListDto>(Messages.WorkingTime.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTimeDto>> GetAsync(int workingTimeId)
        {
            var workingTime = await _workingTimeDal.GetAsync(w => w.Id == workingTimeId);
            if (workingTime != null)
            {
                return new SuccessDataResult<WorkingTimeDto>(new WorkingTimeDto
                {
                    WorkingTime = workingTime
                });
            }
            return new ErrorDataResult<WorkingTimeDto>(Messages.WorkingTime.NotFound(isPlural: false));
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
        public async Task<IResult> UpdateAsync(WorkingTimeUpdateDto workingTimeUpdateDto, string modifiedByName)
        {
            var oldWorkingTime = await _workingTimeDal.GetAsync(w => w.Id == workingTimeUpdateDto.Id);
            var workingTime = _mapper.Map<WorkingTimeUpdateDto, WorkingTime>(workingTimeUpdateDto, oldWorkingTime);
            workingTime.ModifiedByName = modifiedByName;
            await _workingTimeDal.UpdateAsync(workingTime);
            return new SuccessResult(Messages.WorkingTime.workingTimeUpdated);
        }
    }
}
