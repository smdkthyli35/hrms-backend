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
    public class JobSeekerCvManager : IJobSeekerCvService
    {
        private readonly IJobSeekerCvDal _jobSeekerCvDal;
        private readonly IMapper _mapper;

        public JobSeekerCvManager(IJobSeekerCvDal jobSeekerCvDal, IMapper mapper)
        {
            _jobSeekerCvDal = jobSeekerCvDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseekercv.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvValidator))]
        [CacheRemoveAspect("IJobSeekerCvService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvAddDto jobSeekerCvAddDto, string createdByName)
        {
            var jobSeekerCv = _mapper.Map<JobSeekerCv>(jobSeekerCvAddDto);
            jobSeekerCv.CreatedByName = createdByName;
            jobSeekerCv.ModifiedByName = createdByName;
            await _jobSeekerCvDal.AddAsync(jobSeekerCv);
            return new SuccessResult(Messages.JobSeekerCv.jobSeekerCvAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvId, string modifiedByName)
        {
            var result = await _jobSeekerCvDal.AnyAsync(j => j.Id == jobSeekerCvId);
            if (result)
            {
                var jobSeekerCv = await _jobSeekerCvDal.GetAsync(j => j.Id == jobSeekerCvId);
                jobSeekerCv.IsActive = false;
                jobSeekerCv.ModifiedByName = modifiedByName;
                jobSeekerCv.ModifiedDate = DateTime.Now;
                await _jobSeekerCvDal.UpdateAsync(jobSeekerCv);
                return new SuccessResult(Messages.JobSeekerCv.jobSeekerCvDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCv.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvListDto>> GetAllAsync()
        {
            var jobSeekerCvs = await _jobSeekerCvDal.GetAllAsync(null, j => j.JobSeeker);
            if (jobSeekerCvs.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvListDto>(new JobSeekerCvListDto
                {
                    JobSeekerCvs = jobSeekerCvs
                });
            }
            return new ErrorDataResult<JobSeekerCvListDto>(Messages.JobSeekerCv.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvs = await _jobSeekerCvDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeeker);
            if (jobSeekerCvs.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvListDto>(new JobSeekerCvListDto
                {
                    JobSeekerCvs = jobSeekerCvs
                });
            }
            return new ErrorDataResult<JobSeekerCvListDto>(Messages.JobSeekerCv.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvs = await _jobSeekerCvDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeeker);
            if (jobSeekerCvs.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvListDto>(new JobSeekerCvListDto
                {
                    JobSeekerCvs = jobSeekerCvs
                });
            }
            return new ErrorDataResult<JobSeekerCvListDto>(Messages.JobSeekerCv.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvDto>> GetAsync(int jobSeekerCvId)
        {
            var jobSeekerCv = await _jobSeekerCvDal.GetAsync(j => j.Id == jobSeekerCvId, j => j.JobSeeker);
            if (jobSeekerCv != null)
            {
                return new SuccessDataResult<JobSeekerCvDto>(new JobSeekerCvDto
                {
                    JobSeekerCv = jobSeekerCv
                });
            }
            return new ErrorDataResult<JobSeekerCvDto>(Messages.JobSeekerCv.NotFound(isPlural: false));
        }

        public async Task<IDataResult<JobSeekerCvDto>> GetByJobSeekerAsync(int jobSeekerId)
        {
            var jobSeekerCv = await _jobSeekerCvDal.GetByJobSeekerId(jobSeekerId);
            if (jobSeekerCv != null)
            {
                return new SuccessDataResult<JobSeekerCvDto>(new JobSeekerCvDto
                {
                    JobSeekerCv = jobSeekerCv
                });
            }
            return new ErrorDataResult<JobSeekerCvDto>(Messages.JobSeekerCv.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvId)
        {
            var result = await _jobSeekerCvDal.AnyAsync(j => j.Id == jobSeekerCvId);
            if (result)
            {
                var jobSeekerCv = await _jobSeekerCvDal.GetAsync(j => j.Id == jobSeekerCvId);
                await _jobSeekerCvDal.DeleteAsync(jobSeekerCv);
                return new SuccessResult(Messages.JobSeekerCv.jobSeekerCvHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCv.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercv.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvValidator))]
        [CacheRemoveAspect("IJobSeekerCvService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvUpdateDto jobSeekerCvUpdateDto, string modifiedByName)
        {
            var oldJobSeekerCv = await _jobSeekerCvDal.GetAsync(j => j.Id == jobSeekerCvUpdateDto.Id);
            var jobSeekerCv = _mapper.Map<JobSeekerCvUpdateDto, JobSeekerCv>(jobSeekerCvUpdateDto, oldJobSeekerCv);
            jobSeekerCv.ModifiedByName = modifiedByName;
            var updatedjobSeekerCv = await _jobSeekerCvDal.UpdateAsync(jobSeekerCv);
            return new SuccessResult(Messages.JobSeekerCv.jobSeekerCvUpdated);
        }
    }
}
