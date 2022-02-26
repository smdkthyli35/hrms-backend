using Business.Abstract;
using Business.Constants;
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
    public class WorkingTypeManager : IWorkingTypeService
    {
        private readonly IWorkingTypeDal _workingTypeDal;

        public WorkingTypeManager(IWorkingTypeDal workingTypeDal)
        {
            _workingTypeDal = workingTypeDal;
        }

        public async Task<IResult> AddAsync(WorkingType workingType, string createdByName)
        {
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

        public async Task<IDataResult<List<WorkingType>>> GetAllAsync()
        {
            var workingTypes = await _workingTypeDal.GetAllAsync();
            if (workingTypes.Count > -1)
            {
                return new SuccessDataResult<List<WorkingType>>();
            }
            return new ErrorDataResult<List<WorkingType>>(Messages.WorkingType.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<WorkingType>>> GetAllByNonDeletedAndActiveAsync()
        {
            var workingTypes = await _workingTypeDal.GetAllAsync(w => !w.IsDeleted && w.IsActive);
            if (workingTypes.Count > -1)
            {
                return new SuccessDataResult<List<WorkingType>>();
            }
            return new ErrorDataResult<List<WorkingType>>(Messages.WorkingType.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<WorkingType>>> GetAllByNonDeletedAsync()
        {
            var workingTypes = await _workingTypeDal.GetAllAsync(w => !w.IsDeleted);
            if (workingTypes.Count > -1)
            {
                return new SuccessDataResult<List<WorkingType>>();
            }
            return new ErrorDataResult<List<WorkingType>>(Messages.WorkingType.NotFound(isPlural: true));
        }

        public async Task<IDataResult<WorkingType>> GetAsync(int workingTypeId)
        {
            var workingType = await _workingTypeDal.GetAsync(w => w.Id == workingTypeId);
            if (workingType != null)
            {
                return new SuccessDataResult<WorkingType>();
            }
            return new ErrorDataResult<WorkingType>(Messages.WorkingType.NotFound(isPlural: true));
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

        public async Task<IResult> UpdateAsync(WorkingType workingType, string modifiedByName)
        {
            var oldWorkingType = await _workingTypeDal.GetAsync(w => w.Id == workingType.Id);
            oldWorkingType.ModifiedByName = modifiedByName;
            var updatedWorkingType = await _workingTypeDal.UpdateAsync(oldWorkingType);
            return new SuccessResult(Messages.WorkingType.workingTypeUpdated);
        }
    }
}
