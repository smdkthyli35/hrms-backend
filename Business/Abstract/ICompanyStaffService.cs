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
    public interface ICompanyStaffService
    {
        Task<IDataResult<CompanyStaffDto>> GetAsync(int companyStaffId);
        Task<IDataResult<CompanyStaffListDto>> GetAllAsync();
        Task<IDataResult<CompanyStaffListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CompanyStaffListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(CompanyStaffAddDto companyStaffAddDto, string createdByName);
        Task<IResult> UpdateAsync(CompanyStaffUpdateDto companyStaffUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int companyStaffId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int companyStaffId);
    }
}
