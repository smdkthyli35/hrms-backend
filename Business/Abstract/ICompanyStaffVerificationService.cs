using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyStaffVerificationService
    {
        Task<IDataResult<CompanyStaffVerification>> GetAsync(int companyStaffVerificationId);
        Task<IDataResult<List<CompanyStaffVerification>>> GetAllAsync();
        Task<IDataResult<List<CompanyStaffVerification>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<CompanyStaffVerification>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(CompanyStaffVerification companyStaffVerification, string createdByName);
        Task<IResult> UpdateAsync(CompanyStaffVerification companyStaffVerification, string modifiedByName);
        Task<IResult> DeleteAsync(int companyStaffVerificationId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int companyStaffVerificationId);
    }
}
