using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IDataResult<City>> GetAsync(int cityId);
        Task<IDataResult<List<City>>> GetAllAsync();
        Task<IDataResult<List<City>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<City>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(City city, string createdByName);
        Task<IResult> UpdateAsync(City city, string modifiedByName);
        Task<IResult> DeleteAsync(int cityId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int cityId);
    }
}
