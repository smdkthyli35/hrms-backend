using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyStaffService
    {
        Task<IDataResult<CompanyStaff>> GetAsync(int companyStaffId);
        Task<IDataResult<List<CompanyStaff>>> GetAllAsync();
        Task<IDataResult<List<CompanyStaff>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<CompanyStaff>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(CompanyStaff companyStaff, string createdByName);
        Task<IResult> UpdateAsync(CompanyStaff companyStaff, string modifiedByName);
        Task<IResult> DeleteAsync(int companyStaffId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int companyStaffId);
    }
}
