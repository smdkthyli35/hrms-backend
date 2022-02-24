using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJobAdvertService
    {
        Task<IDataResult<JobAdvert>> GetAsync(int jobAdvertId);
        Task<IDataResult<List<JobAdvert>>> GetAllAsync();
        Task<IDataResult<List<JobAdvert>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<JobAdvert>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(JobAdvert jobAdvert, string createdByName);
        Task<IResult> UpdateAsync(JobAdvert jobAdvert, string modifiedByName);
        Task<IResult> DeleteAsync(int jobAdvertId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int jobAdvertId);
    }
}
