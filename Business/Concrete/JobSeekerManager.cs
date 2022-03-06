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
    public class JobSeekerManager : IJobSeekerService
    {
        private readonly IJobSeekerDal _jobSeekerDal;
        private readonly IMapper _mapper;

        public JobSeekerManager(IJobSeekerDal jobSeekerDal, IMapper mapper)
        {
            _jobSeekerDal = jobSeekerDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseeker.add,admin")]
        [ValidationAspect(typeof(JobSeekerValidator))]
        [CacheRemoveAspect("IJobSeekerService.Get")]
        public async Task<IResult> AddAsync(JobSeekerAddDto jobSeekerAddDto, string createdByName)
        {
            var jobSeeker = _mapper.Map<JobSeeker>(jobSeekerAddDto);
            jobSeeker.CreatedByName = createdByName;
            jobSeeker.ModifiedByName = createdByName;
            var addJobSeeker = await _jobSeekerDal.AddAsync(jobSeeker);
            return new SuccessResult(Messages.JobSeeker.Add(addJobSeeker.FirstName, addJobSeeker.LastName));
        }

        public async Task<IResult> DeleteAsync(int jobSeekerId, string modifiedByName)
        {
            var result = await _jobSeekerDal.AnyAsync(j => j.Id == jobSeekerId);
            if (result)
            {
                var jobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerId);
                jobSeeker.IsActive = false;
                jobSeeker.ModifiedByName = modifiedByName;
                jobSeeker.ModifiedDate = DateTime.Now;
                await _jobSeekerDal.UpdateAsync(jobSeeker);
                return new SuccessResult(Messages.JobSeeker.Delete(jobSeeker.FirstName, jobSeeker.LastName));
            }
            return new ErrorResult(Messages.JobSeeker.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerListDto>> GetAllAsync()
        {
            var jobSeekers = await _jobSeekerDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekers.Count > -1)
            {
                return new SuccessDataResult<JobSeekerListDto>(new JobSeekerListDto
                {
                    JobSeekers = jobSeekers
                });
            }
            return new ErrorDataResult<JobSeekerListDto>(Messages.JobSeeker.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekers = await _jobSeekerDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv);
            if (jobSeekers.Count > -1)
            {
                return new SuccessDataResult<JobSeekerListDto>(new JobSeekerListDto
                {
                    JobSeekers = jobSeekers
                });
            }
            return new ErrorDataResult<JobSeekerListDto>(Messages.JobSeeker.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekers = await _jobSeekerDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv);
            if (jobSeekers.Count > -1)
            {
                return new SuccessDataResult<JobSeekerListDto>(new JobSeekerListDto
                {
                    JobSeekers = jobSeekers
                });
            }
            return new ErrorDataResult<JobSeekerListDto>(Messages.JobSeeker.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerDto>> GetAsync(int jobSeekerId)
        {
            var jobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerId, j => j.JobSeekerCv);
            if (jobSeeker != null)
            {
                return new SuccessDataResult<JobSeekerDto>(new JobSeekerDto
                {
                    JobSeeker = jobSeeker
                });
            }
            return new ErrorDataResult<JobSeekerDto>(Messages.JobSeeker.NotFound(isPlural: false));
        }

        public async Task<IDataResult<JobSeekerDto>> GetByIdentityNumberAsync(string identityNumber)
        {
            var jobSeeker = await _jobSeekerDal.GetByIdentityNumber(identityNumber);
            if (jobSeeker != null)
            {
                return new SuccessDataResult<JobSeekerDto>(new JobSeekerDto
                {
                    JobSeeker = jobSeeker
                });
            }
            return new ErrorDataResult<JobSeekerDto>(Messages.JobSeeker.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerId)
        {
            var result = await _jobSeekerDal.AnyAsync(j => j.Id == jobSeekerId);
            if (result)
            {
                var jobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerId);
                await _jobSeekerDal.DeleteAsync(jobSeeker);
                return new SuccessResult(Messages.JobSeeker.HardDelete(jobSeeker.FirstName, jobSeeker.LastName));
            }
            return new SuccessResult(Messages.JobSeeker.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseeker.update,admin")]
        [ValidationAspect(typeof(JobSeekerValidator))]
        [CacheRemoveAspect("IJobSeekerService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerUpdateDto jobSeekerUpdateDto, string modifiedByName)
        {
            var oldJobSeeker = await _jobSeekerDal.GetAsync(j => j.Id == jobSeekerUpdateDto.Id);
            var jobSeeker = _mapper.Map<JobSeekerUpdateDto, JobSeeker>(jobSeekerUpdateDto, oldJobSeeker);
            jobSeeker.ModifiedByName = modifiedByName;
            var updatedJobSeeker = await _jobSeekerDal.UpdateAsync(jobSeeker);
            return new SuccessResult(Messages.JobSeeker.Update(updatedJobSeeker.FirstName, updatedJobSeeker.LastName));
        }
    }
}
