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
    public class JobAdvertManager : IJobAdvertService
    {
        private readonly IJobAdvertDal _jobAdvertDal;
        private readonly IMapper _mapper;

        public JobAdvertManager(IJobAdvertDal jobAdvertDal, IMapper mapper)
        {
            _jobAdvertDal = jobAdvertDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobadvert.add,admin")]
        [ValidationAspect(typeof(JobAdvertValidator))]
        [CacheRemoveAspect("IJobAdvertService.Get")]
        public async Task<IResult> AddAsync(JobAdvertAddDto jobAdvertAddDto, string createdByName)
        {
            var jobAdvert = _mapper.Map<JobAdvert>(jobAdvertAddDto);
            jobAdvert.CreatedByName = createdByName;
            jobAdvert.ModifiedByName = createdByName;
            await _jobAdvertDal.AddAsync(jobAdvert);
            return new SuccessResult(Messages.JobAdvert.jobAdvertAdded);
        }

        public async Task<IResult> DeleteAsync(int jobAdvertId, string modifiedByName)
        {
            var result = await _jobAdvertDal.AnyAsync(j => j.Id == jobAdvertId);
            if (result)
            {
                var jobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertId);
                jobAdvert.IsActive = false;
                jobAdvert.ModifiedByName = modifiedByName;
                jobAdvert.ModifiedDate = DateTime.Now;
                await _jobAdvertDal.UpdateAsync(jobAdvert);
                return new SuccessResult(Messages.JobAdvert.jobAdvertDeleted);
            }
            return new ErrorResult(Messages.JobAdvert.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobAdvertListDto>> GetAllAsync()
        {
            var jobAdverts = await _jobAdvertDal.GetAllAsync(null, j => j.City, j => j.Employer, j => j.JobPosition, j => j.WorkingTime, j => j.WorkingType);
            if (jobAdverts.Count > -1)
            {
                return new SuccessDataResult<JobAdvertListDto>(new JobAdvertListDto
                {
                    JobAdverts = jobAdverts
                });
            }
            return new ErrorDataResult<JobAdvertListDto>(Messages.JobAdvert.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobAdvertListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobAdverts = await _jobAdvertDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.City, j => j.Employer, j => j.JobPosition, j => j.WorkingTime, j => j.WorkingType);
            if (jobAdverts.Count > -1)
            {
                return new SuccessDataResult<JobAdvertListDto>(new JobAdvertListDto
                {
                    JobAdverts = jobAdverts
                });
            }
            return new ErrorDataResult<JobAdvertListDto>(Messages.JobAdvert.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobAdvertListDto>> GetAllByNonDeletedAsync()
        {
            var jobAdverts = await _jobAdvertDal.GetAllAsync(j => !j.IsDeleted, j => j.City, j => j.Employer, j => j.JobPosition, j => j.WorkingTime, j => j.WorkingType);
            if (jobAdverts.Count > -1)
            {
                return new SuccessDataResult<JobAdvertListDto>(new JobAdvertListDto
                {
                    JobAdverts = jobAdverts
                });
            }
            return new ErrorDataResult<JobAdvertListDto>(Messages.JobAdvert.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobAdvertDto>> GetAsync(int jobAdvertId)
        {
            var jobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertId);
            if (jobAdvert != null)
            {
                return new SuccessDataResult<JobAdvertDto>(new JobAdvertDto
                {
                    JobAdvert = jobAdvert
                });
            }
            return new ErrorDataResult<JobAdvertDto>(Messages.JobAdvert.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int jobAdvertId)
        {
            var result = await _jobAdvertDal.AnyAsync(j => j.Id == jobAdvertId);
            if (result)
            {
                var jobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertId);
                await _jobAdvertDal.DeleteAsync(jobAdvert);
                return new SuccessResult(Messages.JobAdvert.jobAdvertHardDeleted);
            }
            return new SuccessResult(Messages.JobAdvert.NotFound(isPlural: false));
        }

        [SecuredOperation("jobadvert.update,admin")]
        [ValidationAspect(typeof(JobAdvertValidator))]
        [CacheRemoveAspect("IJobAdvertService.Get")]
        public async Task<IResult> UpdateAsync(JobAdvertUpdateDto jobAdvertUpdateDto, string modifiedByName)
        {
            var oldJobAdvert = await _jobAdvertDal.GetAsync(j => j.Id == jobAdvertUpdateDto.Id);
            var jobAdvert = _mapper.Map<JobAdvertUpdateDto, JobAdvert>(jobAdvertUpdateDto, oldJobAdvert);
            jobAdvert.ModifiedByName = modifiedByName;
            await _jobAdvertDal.UpdateAsync(jobAdvert);
            return new SuccessResult(Messages.JobAdvert.jobAdvertUpdated);
        }
    }
}
