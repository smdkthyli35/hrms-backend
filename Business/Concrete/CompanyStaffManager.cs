using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
        private readonly IMapper _mapper;

        public CompanyStaffManager(ICompanyStaffDal companyStaffDal, IMapper mapper)
        {
            _companyStaffDal = companyStaffDal;
            _mapper = mapper;
        }

        [SecuredOperation("companystaff.add,admin")]
        [ValidationAspect(typeof(CompanyStaffValidator))]
        [CacheRemoveAspect("ICompanyStaffService.Get")]
        public async Task<IResult> AddAsync(CompanyStaffAddDto companyStaffAddDto, string createdByName)
        {
            var companyStaff = _mapper.Map<CompanyStaff>(companyStaffAddDto);
            companyStaff.CreatedByName = createdByName;
            companyStaff.ModifiedByName = createdByName;
            await _companyStaffDal.AddAsync(companyStaff);
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

        [CacheAspect]
        public async Task<IDataResult<CompanyStaffListDto>> GetAllAsync()
        {
            var companyStaffs = await _companyStaffDal.GetAllAsync();
            if (companyStaffs.Count > -1)
            {
                return new SuccessDataResult<CompanyStaffListDto>(new CompanyStaffListDto
                {
                    CompanyStaffs = companyStaffs
                });
            }
            return new ErrorDataResult<CompanyStaffListDto>(Messages.CompanyStaff.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<CompanyStaffListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var companyStaffs = await _companyStaffDal.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (companyStaffs.Count > -1)
            {
                return new SuccessDataResult<CompanyStaffListDto>(new CompanyStaffListDto
                {
                    CompanyStaffs = companyStaffs
                });
            }
            return new ErrorDataResult<CompanyStaffListDto>(Messages.CompanyStaff.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<CompanyStaffListDto>> GetAllByNonDeletedAsync()
        {
            var companyStaffs = await _companyStaffDal.GetAllAsync(c => !c.IsDeleted);
            if (companyStaffs.Count > -1)
            {
                return new SuccessDataResult<CompanyStaffListDto>(new CompanyStaffListDto
                {
                    CompanyStaffs = companyStaffs
                });
            }
            return new ErrorDataResult<CompanyStaffListDto>(Messages.CompanyStaff.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<CompanyStaffDto>> GetAsync(int companyStaffId)
        {
            var companyStaff = await _companyStaffDal.GetAsync(c => c.Id == companyStaffId);
            if (companyStaff != null)
            {
                return new SuccessDataResult<CompanyStaffDto>(new CompanyStaffDto
                {
                    CompanyStaff = companyStaff
                });
            }
            return new ErrorDataResult<CompanyStaffDto>(Messages.CompanyStaff.NotFound(isPlural: false));
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

        [SecuredOperation("companystaff.update,admin")]
        [CacheRemoveAspect("ICompanyStaffService.Get")]
        [ValidationAspect(typeof(CompanyStaffValidator))]
        public async Task<IResult> UpdateAsync(CompanyStaffUpdateDto companyStaffUpdateDto, string modifiedByName)
        {
            var oldCompanyStaff = await _companyStaffDal.GetAsync(a => a.Id == companyStaffUpdateDto.Id);
            var companyStaff = _mapper.Map<CompanyStaffUpdateDto, CompanyStaff>(companyStaffUpdateDto, oldCompanyStaff);
            companyStaff.ModifiedByName = modifiedByName;
            var updatedCompanyStaff = await _companyStaffDal.UpdateAsync(companyStaff);
            return new SuccessResult(Messages.CompanyStaff.Update(updatedCompanyStaff.FirstName, updatedCompanyStaff.LastName));
        }
    }
}
