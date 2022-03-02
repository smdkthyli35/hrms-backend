using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> GetAsync(int userId);
        Task<IDataResult<List<User>>> GetAllAsync();
        Task<IDataResult<List<User>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<User>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(User user, string createdByName);
        Task<IResult> UpdateAsync(User user, string modifiedByName);
        Task<IResult> DeleteAsync(int userId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int userId);
    }
}
