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
    public class WorkingTypeManager : IWorkingTypeService
    {
        private readonly IWorkingTypeDal _workingTypeDal;
        private readonly IMapper _mapper;

        public WorkingTypeManager(IWorkingTypeDal workingTypeDal, IMapper mapper)
        {
            _workingTypeDal = workingTypeDal;
            _mapper = mapper;
        }

        [SecuredOperation("workingtype.add,admin")]
        [ValidationAspect(typeof(WorkingTypeValidator))]
        [CacheRemoveAspect("IWorkingTypeService.Get")]
        public async Task<IResult> AddAsync(WorkingTypeAddDto workingTypeAddDto, string createdByName)
        {
            var workingType = _mapper.Map<WorkingType>(workingTypeAddDto);
            workingType.CreatedByName = createdByName;
            workingType.ModifiedByName = createdByName;
            await _workingTypeDal.AddAsync(workingType);
            return new SuccessResult(Messages.WorkingType.workingTypeAdded);
        }

        public async Task<IResult> DeleteAsync(int workingTypeId, string modifiedByName)
        {
            var result = await _workingTypeDal.AnyAsync(w => w.Id == workingTypeId);
            if (result)
            {
                var workingType = await _workingTypeDal.GetAsync(w => w.Id == workingTypeId);
                workingType.IsActive = false;
                workingType.ModifiedByName = modifiedByName;
                workingType.ModifiedDate = DateTime.Now;
                await _workingTypeDal.UpdateAsync(workingType);
                return new SuccessResult(Messages.WorkingType.workingTypeDeleted);
            }
            return new ErrorResult(Messages.WorkingType.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTypeListDto>> GetAllAsync()
        {
            var workingTypes = await _workingTypeDal.GetAllAsync();
            if (workingTypes.Count > -1)
            {
                return new SuccessDataResult<WorkingTypeListDto>(new WorkingTypeListDto
                {
                    WorkingTypes = workingTypes
                });
            }
            return new ErrorDataResult<WorkingTypeListDto>(Messages.WorkingType.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTypeListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var workingTypes = await _workingTypeDal.GetAllAsync(w => !w.IsDeleted && w.IsActive);
            if (workingTypes.Count > -1)
            {
                return new SuccessDataResult<WorkingTypeListDto>(new WorkingTypeListDto
                {
                    WorkingTypes = workingTypes
                });
            }
            return new ErrorDataResult<WorkingTypeListDto>(Messages.WorkingType.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTypeListDto>> GetAllByNonDeletedAsync()
        {
            var workingTypes = await _workingTypeDal.GetAllAsync(w => !w.IsDeleted);
            if (workingTypes.Count > -1)
            {
                return new SuccessDataResult<WorkingTypeListDto>(new WorkingTypeListDto
                {
                    WorkingTypes = workingTypes
                });
            }
            return new ErrorDataResult<WorkingTypeListDto>(Messages.WorkingType.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WorkingTypeDto>> GetAsync(int workingTypeId)
        {
            var workingType = await _workingTypeDal.GetAsync(w => w.Id == workingTypeId);
            if (workingType != null)
            {
                return new SuccessDataResult<WorkingTypeDto>(new WorkingTypeDto
                {
                    WorkingType = workingType
                });
            }
            return new ErrorDataResult<WorkingTypeDto>(Messages.WorkingType.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int workingTypeId)
        {
            var result = await _workingTypeDal.AnyAsync(w => w.Id == workingTypeId);
            if (result)
            {
                var workingType = await _workingTypeDal.GetAsync(w => w.Id == workingTypeId);
                await _workingTypeDal.DeleteAsync(workingType);
                return new SuccessResult(Messages.WorkingType.workingTypeHardDeleted);
            }
            return new SuccessResult(Messages.WorkingType.NotFound(isPlural: false));
        }

        [SecuredOperation("workingtype.update,admin")]
        [ValidationAspect(typeof(WorkingTypeValidator))]
        [CacheRemoveAspect("IWorkingTypeService.Get")]
        public async Task<IResult> UpdateAsync(WorkingTypeUpdateDto workingTypeUpdateDto, string modifiedByName)
        {
            var oldWorkingType = await _workingTypeDal.GetAsync(w => w.Id == workingTypeUpdateDto.Id);
            var workingType = _mapper.Map<WorkingTypeUpdateDto, WorkingType>(workingTypeUpdateDto, oldWorkingType);
            workingType.ModifiedByName = modifiedByName;
            await _workingTypeDal.UpdateAsync(workingType);
            return new SuccessResult(Messages.WorkingType.workingTypeUpdated);
        }
    }
}
