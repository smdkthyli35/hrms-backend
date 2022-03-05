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
    public interface IJobAdvertService
    {
        Task<IDataResult<JobAdvertDto>> GetAsync(int jobAdvertId);
        Task<IDataResult<JobAdvertListDto>> GetAllAsync();
        Task<IDataResult<JobAdvertListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<JobAdvertListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobAdvertAddDto jobAdvertAddDto, string createdByName);
        Task<IResult> UpdateAsync(JobAdvertUpdateDto jobAdvertUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int jobAdvertId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobAdvertId);
    }
}
