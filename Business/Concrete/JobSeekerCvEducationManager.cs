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
    public class JobSeekerCvEducationManager : IJobSeekerCvEducationService
    {
        private readonly IJobSeekerCvEducationDal _jobSeekerCvEducationDal;
        private readonly IMapper _mapper;

        public JobSeekerCvEducationManager(IJobSeekerCvEducationDal jobSeekerCvEducationDal, IMapper mapper)
        {
            _jobSeekerCvEducationDal = jobSeekerCvEducationDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseekercveducation.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvEducationValidator))]
        [CacheRemoveAspect("IJobSeekerCvEducationService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvEducationAddDto jobSeekerCvEducationAddDto, string createdByName)
        {
            var jobSeekerCvEducation = _mapper.Map<JobSeekerCvEducation>(jobSeekerCvEducationAddDto);
            jobSeekerCvEducation.CreatedByName = createdByName;
            jobSeekerCvEducation.ModifiedByName = createdByName;
            await _jobSeekerCvEducationDal.AddAsync(jobSeekerCvEducation);
            return new SuccessResult(Messages.JobSeekerCvEducation.jobSeekerCvEducationAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvEducationId, string modifiedByName)
        {
            var result = await _jobSeekerCvEducationDal.AnyAsync(j => j.Id == jobSeekerCvEducationId);
            if (result)
            {
                var jobSeekerCvEducation = await _jobSeekerCvEducationDal.GetAsync(j => j.Id == jobSeekerCvEducationId);
                jobSeekerCvEducation.IsActive = false;
                jobSeekerCvEducation.ModifiedByName = modifiedByName;
                jobSeekerCvEducation.ModifiedDate = DateTime.Now;
                await _jobSeekerCvEducationDal.UpdateAsync(jobSeekerCvEducation);
                return new SuccessResult(Messages.JobSeekerCvEducation.jobSeekerCvEducationDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvEducation.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvEducationListDto>> GetAllAsync()
        {
            var jobSeekerCvEducations = await _jobSeekerCvEducationDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekerCvEducations.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvEducationListDto>(new JobSeekerCvEducationListDto
                {
                    JobSeekerCvEducations = jobSeekerCvEducations
                });
            }
            return new ErrorDataResult<JobSeekerCvEducationListDto>(Messages.JobSeekerCvEducation.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvEducationListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvEducations = await _jobSeekerCvEducationDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.JobSeekerCv);
            if (jobSeekerCvEducations.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvEducationListDto>(new JobSeekerCvEducationListDto
                {
                    JobSeekerCvEducations = jobSeekerCvEducations
                });
            }
            return new ErrorDataResult<JobSeekerCvEducationListDto>(Messages.JobSeekerCvEducation.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvEducationListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvEducations = await _jobSeekerCvEducationDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.JobSeekerCv);
            if (jobSeekerCvEducations.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvEducationListDto>(new JobSeekerCvEducationListDto
                {
                    JobSeekerCvEducations = jobSeekerCvEducations
                });
            }
            return new ErrorDataResult<JobSeekerCvEducationListDto>(Messages.JobSeekerCvEducation.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvEducationDto>> GetAsync(int jobSeekerCvEducationId)
        {
            var jobSeekerCvEducation = await _jobSeekerCvEducationDal.GetAsync(j => j.Id == jobSeekerCvEducationId, j => j.JobSeekerCv);
            if (jobSeekerCvEducation != null)
            {
                return new SuccessDataResult<JobSeekerCvEducationDto>(new JobSeekerCvEducationDto
                {
                    JobSeekerCvEducation = jobSeekerCvEducation
                });
            }
            return new ErrorDataResult<JobSeekerCvEducationDto>();
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvEducationId)
        {
            var result = await _jobSeekerCvEducationDal.AnyAsync(j => j.Id == jobSeekerCvEducationId);
            if (result)
            {
                var jobSeekerCvEducation = await _jobSeekerCvEducationDal.GetAsync(j => j.Id == jobSeekerCvEducationId);
                await _jobSeekerCvEducationDal.DeleteAsync(jobSeekerCvEducation);
                return new SuccessResult(Messages.JobSeekerCvEducation.jobSeekerCvEducationHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvEducation.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercveducation.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvEducationValidator))]
        [CacheRemoveAspect("IJobSeekerCvEducationService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvEducationUpdateDto jobSeekerCvEducationUpdateDto, string modifiedByName)
        {
            var oldjobSeekerCvEducation = await _jobSeekerCvEducationDal.GetAsync(j => j.Id == jobSeekerCvEducationUpdateDto.Id);
            var jobSeekerCvEducation = _mapper.Map<JobSeekerCvEducationUpdateDto, JobSeekerCvEducation>(jobSeekerCvEducationUpdateDto, oldjobSeekerCvEducation);
            jobSeekerCvEducation.ModifiedByName = modifiedByName;
            await _jobSeekerCvEducationDal.UpdateAsync(jobSeekerCvEducation);
            return new SuccessResult(Messages.JobSeekerCvEducation.jobSeekerCvEducationUpdated);
        }
    }
}
