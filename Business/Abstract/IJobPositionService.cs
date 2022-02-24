using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobPositionService
    {
        Task<IDataResult<JobPosition>> GetAsync(int jobPositionId);
        Task<IDataResult<List<JobPosition>>> GetAllAsync();
        Task<IDataResult<List<JobPosition>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobPosition>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobPosition jobPosition, string createdByName);
        Task<IResult> UpdateAsync(JobPosition jobPosition, string modifiedByName);
        Task<IResult> DeleteAsync(int jobPositionId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobPositionId);
    }
}
