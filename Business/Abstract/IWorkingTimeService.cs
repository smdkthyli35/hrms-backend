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
    public interface IWorkingTimeService
    {
        Task<IDataResult<WorkingTimeDto>> GetAsync(int workingTimeId);
        Task<IDataResult<WorkingTimeListDto>> GetAllAsync();
        Task<IDataResult<WorkingTimeListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<WorkingTimeListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(WorkingTimeAddDto workingTimeAddDto, string createdByName);
        Task<IResult> UpdateAsync(WorkingTimeUpdateDto workingTimeUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int workingTimeId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int workingTimeId);
    }
}
