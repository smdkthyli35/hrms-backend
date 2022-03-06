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
    public class JobSeekerCvExperienceManager : IJobSeekerCvExperienceService
    {
        private readonly IJobSeekerCvExperienceDal _jobSeekerCvExperienceDal;
        private readonly IMapper _mapper;

        public JobSeekerCvExperienceManager(IJobSeekerCvExperienceDal jobSeekerCvExperienceDal, IMapper mapper)
        {
            _jobSeekerCvExperienceDal = jobSeekerCvExperienceDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseekercvexperience.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvExperienceValidator))]
        [CacheRemoveAspect("IJobSeekerCvExperienceService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvExperienceAddDto jobSeekerCvExperienceAddDto, string createdByName)
        {
            var jobSeekerCvExperience = _mapper.Map<JobSeekerCvExperience>(jobSeekerCvExperienceAddDto);
            jobSeekerCvExperience.CreatedByName = createdByName;
            jobSeekerCvExperience.ModifiedByName = createdByName;
            await _jobSeekerCvExperienceDal.AddAsync(jobSeekerCvExperience);
            return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvExperienceId, string modifiedByName)
        {
            var result = await _jobSeekerCvExperienceDal.AnyAsync(j => j.Id == jobSeekerCvExperienceId);
            if (result)
            {
                var jobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceId);
                jobSeekerCvExperience.IsActive = false;
                jobSeekerCvExperience.ModifiedByName = modifiedByName;
                jobSeekerCvExperience.ModifiedDate = DateTime.Now;
                await _jobSeekerCvExperienceDal.UpdateAsync(jobSeekerCvExperience);
                return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvExperience.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvExperienceListDto>> GetAllAsync()
        {
            var jobSeekerCvExperiences = await _jobSeekerCvExperienceDal.GetAllAsync(null, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperiences.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvExperienceListDto>(new JobSeekerCvExperienceListDto
                {
                    JobSeekerCvExperiences = jobSeekerCvExperiences
                });
            }
            return new ErrorDataResult<JobSeekerCvExperienceListDto>(Messages.JobSeekerCvExperience.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvExperienceListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvExperiences = await _jobSeekerCvExperienceDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperiences.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvExperienceListDto>(new JobSeekerCvExperienceListDto
                {
                    JobSeekerCvExperiences = jobSeekerCvExperiences
                });
            }
            return new ErrorDataResult<JobSeekerCvExperienceListDto>(Messages.JobSeekerCvExperience.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvExperienceListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvExperiences = await _jobSeekerCvExperienceDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperiences.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvExperienceListDto>(new JobSeekerCvExperienceListDto
                {
                    JobSeekerCvExperiences = jobSeekerCvExperiences
                });
            }
            return new ErrorDataResult<JobSeekerCvExperienceListDto>(Messages.JobSeekerCvExperience.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvExperienceDto>> GetAsync(int jobSeekerCvExperienceId)
        {
            var jobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceId, j => j.JobSeekerCv, j => j.JobPosition);
            if (jobSeekerCvExperience != null)
            {
                return new SuccessDataResult<JobSeekerCvExperienceDto>(new JobSeekerCvExperienceDto
                {
                    JobSeekerCvExperience = jobSeekerCvExperience
                });
            }
            return new ErrorDataResult<JobSeekerCvExperienceDto>(Messages.JobSeekerCvExperience.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvExperienceId)
        {
            var result = await _jobSeekerCvExperienceDal.AnyAsync(j => j.Id == jobSeekerCvExperienceId);
            if (result)
            {
                var jobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceId);
                await _jobSeekerCvExperienceDal.DeleteAsync(jobSeekerCvExperience);
                return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvExperience.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercvexperience.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvExperienceValidator))]
        [CacheRemoveAspect("IJobSeekerCvExperienceService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvExperienceUpdateDto jobSeekerCvExperienceUpdateDto, string modifiedByName)
        {
            var oldJobSeekerCvExperience = await _jobSeekerCvExperienceDal.GetAsync(j => j.Id == jobSeekerCvExperienceUpdateDto.Id);
            var jobSeekerCvExperience = _mapper.Map<JobSeekerCvExperienceUpdateDto, JobSeekerCvExperience>(jobSeekerCvExperienceUpdateDto, oldJobSeekerCvExperience);
            jobSeekerCvExperience.ModifiedByName = modifiedByName;
            await _jobSeekerCvExperienceDal.UpdateAsync(jobSeekerCvExperience);
            return new SuccessResult(Messages.JobSeekerCvExperience.jobSeekerCvExperienceUpdated);
        }
    }
}
