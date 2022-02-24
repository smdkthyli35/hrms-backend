using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkingTimeService
    {
        Task<IDataResult<WorkingTime>> GetAsync(int workingTimeId);
        Task<IDataResult<List<WorkingTime>>> GetAllAsync();
        Task<IDataResult<List<WorkingTime>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<WorkingTime>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(WorkingTime workingTime, string createdByName);
        Task<IResult> UpdateAsync(WorkingTime workingTime, string modifiedByName);
        Task<IResult> DeleteAsync(int workingTimeId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int workingTimeId);
    }
}
