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
    public interface IEmployerService
    {
        Task<IDataResult<EmployerDto>> GetAsync(int employerId);
        Task<IDataResult<EmployerDto>> GetByCorporateEmailAsync(string corporateEmail);
        Task<IDataResult<EmployerListDto>> GetAllAsync();
        Task<IDataResult<EmployerListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<EmployerListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(EmployerAddDto employerAddDto, string createdByName);
        Task<IResult> UpdateAsync(EmployerUpdateDto employerUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int employerId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int employerId);
    }
}
