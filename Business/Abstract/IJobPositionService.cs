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
    public interface IJobPositionService
    {
        Task<IDataResult<JobPositionDto>> GetAsync(int jobPositionId);
        Task<IDataResult<JobPositionListDto>> GetAllAsync();
        Task<IDataResult<JobPositionListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobPositionListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobPositionAddDto jobPositionAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobPositionUpdateDto jobPositionUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobPositionId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobPositionId);
    }
}
