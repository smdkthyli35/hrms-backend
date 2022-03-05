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
    public class JobPositionManager : IJobPositionService
    {
        private readonly IJobPositionDal _jobPositionDal;
        private readonly IMapper _mapper;

        public JobPositionManager(IJobPositionDal jobPositionDal, IMapper mapper)
        {
            _jobPositionDal = jobPositionDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobposition.add,admin")]
        [ValidationAspect(typeof(JobPositionValidator))]
        [CacheRemoveAspect("IJobPositionService.Get")]
        public async Task<IResult> AddAsync(JobPositionAddDto jobPositionAddDto, string createdByName)
        {
            var jobPosition = _mapper.Map<JobPosition>(jobPositionAddDto);
            jobPosition.CreatedByName = createdByName;
            jobPosition.ModifiedByName = createdByName;
            await _jobPositionDal.AddAsync(jobPosition);
            return new SuccessResult(Messages.JobPosition.Add(jobPosition.Title));
        }

        public async Task<IResult> DeleteAsync(int jobPositionId, string modifiedByName)
        {
            var result = await _jobPositionDal.AnyAsync(j => j.Id == jobPositionId);
            if (result)
            {
                var jobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionId);
                jobPosition.IsActive = false;
                jobPosition.ModifiedByName = modifiedByName;
                jobPosition.ModifiedDate = DateTime.Now;
                await _jobPositionDal.UpdateAsync(jobPosition);
                return new SuccessResult(Messages.JobPosition.Delete(jobPosition.Title));
            }
            return new ErrorResult(Messages.JobPosition.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobPositionListDto>> GetAllAsync()
        {
            var jobPositions = await _jobPositionDal.GetAllAsync();
            if (jobPositions.Count > -1)
            {
                return new SuccessDataResult<JobPositionListDto>(new JobPositionListDto
                {
                    JobPositions = jobPositions
                });
            }
            return new ErrorDataResult<JobPositionListDto>(Messages.JobPosition.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobPositionListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobPositions = await _jobPositionDal.GetAllAsync(j => !j.IsDeleted && j.IsActive);
            if (jobPositions.Count > -1)
            {
                return new SuccessDataResult<JobPositionListDto>(new JobPositionListDto
                {
                    JobPositions = jobPositions
                });
            }
            return new ErrorDataResult<JobPositionListDto>(Messages.JobPosition.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobPositionListDto>> GetAllByNonDeletedAsync()
        {
            var jobPositions = await _jobPositionDal.GetAllAsync(j => !j.IsDeleted);
            if (jobPositions.Count > -1)
            {
                return new SuccessDataResult<JobPositionListDto>(new JobPositionListDto
                {
                    JobPositions = jobPositions
                });
            }
            return new ErrorDataResult<JobPositionListDto>(Messages.JobPosition.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobPositionDto>> GetAsync(int jobPositionId)
        {
            var jobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionId);
            if (jobPosition != null)
            {
                return new SuccessDataResult<JobPositionDto>(new JobPositionDto
                {
                    JobPosition = jobPosition
                });
            }
            return new ErrorDataResult<JobPositionDto>();
        }

        public async Task<IResult> HardDeleteAsync(int jobPositionId)
        {
            var result = await _jobPositionDal.AnyAsync(j => j.Id == jobPositionId);
            if (result)
            {
                var jobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionId);
                await _jobPositionDal.DeleteAsync(jobPosition);
                return new SuccessResult(Messages.JobPosition.HardDelete(jobPosition.Title));
            }
            return new SuccessResult(Messages.JobPosition.NotFound(isPlural: false));
        }

        [SecuredOperation("jobposition.update,admin")]
        [ValidationAspect(typeof(JobPositionValidator))]
        [CacheRemoveAspect("IJobPositionService.Get")]
        public async Task<IResult> UpdateAsync(JobPositionUpdateDto jobPositionUpdateDto, string modifiedByName)
        {
            var oldJobPosition = await _jobPositionDal.GetAsync(j => j.Id == jobPositionUpdateDto.Id);
            var jobPosition = _mapper.Map<JobPositionUpdateDto, JobPosition>(jobPositionUpdateDto, oldJobPosition);
            jobPosition.ModifiedByName = modifiedByName;
            var updatedJobAdvert = await _jobPositionDal.UpdateAsync(jobPosition);
            return new SuccessResult(Messages.JobPosition.Update(updatedJobAdvert.Title));
        }
    }
}
