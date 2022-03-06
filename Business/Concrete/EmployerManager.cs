using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
    public class EmployerManager : IEmployerService
    {
        private readonly IEmployerDal _employerDal;
        private readonly IMapper _mapper;

        public EmployerManager(IEmployerDal employerDal, IMapper mapper)
        {
            _employerDal = employerDal;
            _mapper = mapper;
        }

        [SecuredOperation("employer.add,admin")]
        [ValidationAspect(typeof(EmployerValidator))]
        [CacheRemoveAspect("IEmployerService.Get")]
        public async Task<IResult> AddAsync(EmployerAddDto employerAddDto, string createdByName)
        {
            var employer = _mapper.Map<Employer>(employerAddDto);
            employer.CreatedByName = createdByName;
            employer.ModifiedByName = createdByName;
            await _employerDal.AddAsync(employer);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int employerId, string modifiedByName)
        {
            var result = await _employerDal.AnyAsync(e => e.Id == employerId);
            if (result)
            {
                var employer = await _employerDal.GetAsync(e => e.Id == employerId);
                employer.IsDeleted = true;
                employer.ModifiedByName = modifiedByName;
                employer.ModifiedDate = DateTime.Now;
                await _employerDal.UpdateAsync(employer);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.Employer.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<EmployerListDto>> GetAllAsync()
        {
            var employers = await _employerDal.GetAllAsync();
            if (employers.Count > -1)
            {
                return new SuccessDataResult<EmployerListDto>(new EmployerListDto
                {
                    Employers = employers
                });
            }
            return new ErrorDataResult<EmployerListDto>(Messages.Employer.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<EmployerListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var employers = await _employerDal.GetAllAsync(e => !e.IsDeleted && e.IsActive);
            if (employers.Count > -1)
            {
                return new SuccessDataResult<EmployerListDto>(new EmployerListDto
                {
                    Employers = employers
                });
            }
            return new ErrorDataResult<EmployerListDto>(Messages.Employer.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<EmployerListDto>> GetAllByNonDeletedAsync()
        {
            var employers = await _employerDal.GetAllAsync(e => !e.IsDeleted);
            if (employers.Count > -1)
            {
                return new SuccessDataResult<EmployerListDto>(new EmployerListDto
                {
                    Employers = employers
                });
            }
            return new ErrorDataResult<EmployerListDto>(Messages.Employer.NotFound(isPlural: true));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public async Task<IDataResult<EmployerDto>> GetAsync(int employerId)
        {
            var employer = await _employerDal.GetAsync(e => e.Id == employerId);
            if (employer != null)
            {
                return new SuccessDataResult<EmployerDto>(new EmployerDto
                {
                    Employer = employer
                });
            }
            return new ErrorDataResult<EmployerDto>(Messages.Employer.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int employerId)
        {
            var result = await _employerDal.AnyAsync(e => e.Id == employerId);
            if (result)
            {
                var employer = await _employerDal.GetAsync(e => e.Id == employerId);
                await _employerDal.DeleteAsync(employer);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.Employer.NotFound(isPlural: false));
        }

        [SecuredOperation("employer.update,admin")]
        [ValidationAspect(typeof(EmployerValidator))]
        [CacheRemoveAspect("IEmployerService.Get")]
        public async Task<IResult> UpdateAsync(EmployerUpdateDto employerUpdateDto, string modifiedByName)
        {
            var oldEmployer = await _employerDal.GetAsync(e => e.Id == employerUpdateDto.Id);
            var employer = _mapper.Map<EmployerUpdateDto, Employer>(employerUpdateDto, oldEmployer);
            employer.ModifiedByName = modifiedByName;
            var updatedEmployer = await _employerDal.UpdateAsync(employer);
            return new SuccessResult();
        }
    }
}
