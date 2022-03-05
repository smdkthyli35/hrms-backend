using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkingTypeService
    {
        Task<IDataResult<WorkingTypeDto>> GetAsync(int workingTypeId);
        Task<IDataResult<WorkingTypeListDto>> GetAllAsync();
        Task<IDataResult<WorkingTypeListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<WorkingTypeListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(WorkingTypeAddDto workingTypeAddDto, string createdByName);
        Task<IResult> UpdateAsync(WorkingTypeUpdateDto workingTypeUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int workingTypeId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int workingTypeId);
    }
}
