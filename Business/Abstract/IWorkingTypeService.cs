using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkingTypeService
    {
        Task<IDataResult<WorkingType>> GetAsync(int workingTypeId);
        Task<IDataResult<List<WorkingType>>> GetAllAsync();
        Task<IDataResult<List<WorkingType>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<WorkingType>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(WorkingType workingType, string createdByName);
        Task<IResult> UpdateAsync(WorkingType workingType, string modifiedByName);
        Task<IResult> DeleteAsync(int workingTypeId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int workingTypeId);
    }
}
