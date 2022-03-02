using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyStaffManager : ICompanyStaffService
    {
        private readonly ICompanyStaffDal _companyStaffDal;

        public CompanyStaffManager(ICompanyStaffDal companyStaffDal)
        {
            _companyStaffDal = companyStaffDal;
        }

        public async Task<IResult> AddAsync(CompanyStaff companyStaff, string createdByName)
        {
            companyStaff.CreatedByName = createdByName;
            companyStaff.ModifiedByName = createdByName;
            var addCompanyStaff = await _companyStaffDal.AddAsync(companyStaff);
            return new SuccessResult(Messages.CompanyStaff.Add(companyStaff.FirstName, companyStaff.LastName));
        }

        public async Task<IResult> DeleteAsync(int companyStaffId, string modifiedByName)
        {
            var result = await _companyStaffDal.AnyAsync(c => c.Id == companyStaffId);
            if (result)
            {
                var companyStaff = await _companyStaffDal.GetAsync(c => c.Id == companyStaffId);
                companyStaff.IsDeleted = true;
                companyStaff.ModifiedByName = modifiedByName;
                companyStaff.ModifiedDate = DateTime.Now;
                await _companyStaffDal.UpdateAsync(companyStaff);
                return new SuccessResult(Messages.CompanyStaff.Delete(companyStaff.FirstName, companyStaff.LastName));
            }
            return new ErrorResult(Messages.CompanyStaff.NotFound(isPlural: false));
        }

        public async Task<IDataResult<List<CompanyStaff>>> GetAllAsync()
        {
            var companyStaffs = await _companyStaffDal.GetAllAsync();
            if (companyStaffs.Count > -1)
            {
                return new SuccessDataResult<List<CompanyStaff>>();
            }
            return new ErrorDataResult<List<CompanyStaff>>(Messages.CompanyStaff.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<CompanyStaff>>> GetAllByNonDeletedAndActiveAsync()
        {
            var companyStaffs = await _companyStaffDal.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (companyStaffs.Count > -1)
            {
                return new SuccessDataResult<List<CompanyStaff>>();
            }
            return new ErrorDataResult<List<CompanyStaff>>(Messages.CompanyStaff.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<CompanyStaff>>> GetAllByNonDeletedAsync()
        {
            var companyStaffs = await _companyStaffDal.GetAllAsync(c => !c.IsDeleted);
            if (companyStaffs.Count > -1)
            {
                return new SuccessDataResult<List<CompanyStaff>>();
            }
            return new ErrorDataResult<List<CompanyStaff>>(Messages.CompanyStaff.NotFound(isPlural: true));
        }

        public async Task<IDataResult<CompanyStaff>> GetAsync(int companyStaffId)
        {
            var companyStaff = await _companyStaffDal.GetAsync(c => c.Id == companyStaffId);
            if (companyStaff != null)
            {
                return new SuccessDataResult<CompanyStaff>();
            }
            return new ErrorDataResult<CompanyStaff>(Messages.CompanyStaff.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int companyStaffId)
        {
            var result = await _companyStaffDal.AnyAsync(c => c.Id == companyStaffId);
            if (result)
            {
                var companyStaff = await _companyStaffDal.GetAsync(c => c.Id == companyStaffId);
                await _companyStaffDal.DeleteAsync(companyStaff);
                return new SuccessResult(Messages.CompanyStaff.Delete(companyStaff.FirstName, companyStaff.LastName));
            }
            return new ErrorResult(Messages.CompanyStaff.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(CompanyStaff companyStaff, string modifiedByName)
        {
            var oldCompanyStaff = await _companyStaffDal.GetAsync(a => a.Id == companyStaff.Id);
            oldCompanyStaff.ModifiedByName = modifiedByName;
            var updatedCompanyStaff = await _companyStaffDal.UpdateAsync(oldCompanyStaff);
            return new SuccessResult(Messages.CompanyStaff.Update(updatedCompanyStaff.FirstName, updatedCompanyStaff.LastName));
        }
    }
}
