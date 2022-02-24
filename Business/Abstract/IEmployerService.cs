using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployerService
    {
        Task<IDataResult<Employer>> GetAsync(int employerId);
        Task<IDataResult<List<Employer>>> GetAllAsync();
        Task<IDataResult<List<Employer>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<Employer>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(Employer employer, string createdByName);
        Task<IResult> UpdateAsync(Employer employer, string modifiedByName);
        Task<IResult> DeleteAsync(int employerId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int employerId);
    }
}
