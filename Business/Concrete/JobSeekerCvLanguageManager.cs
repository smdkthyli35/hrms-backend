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
    public class JobSeekerCvLanguageManager : IJobSeekerCvLanguageService
    {
        private readonly IJobSeekerCvLanguageDal _jobSeekerCvLanguageDal;
        private readonly IMapper _mapper;

        public JobSeekerCvLanguageManager(IJobSeekerCvLanguageDal jobSeekerCvLanguageDal, IMapper mapper)
        {
            _jobSeekerCvLanguageDal = jobSeekerCvLanguageDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseekercvlanguage.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvLanguageValidator))]
        [CacheRemoveAspect("IJobSeekerCvLanguageService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvLanguageAddDto jobSeekerCvLanguageAddDto, string createdByName)
        {
            var jobSeekerCvLanguage = _mapper.Map<JobSeekerCvLanguage>(jobSeekerCvLanguageAddDto);
            jobSeekerCvLanguage.CreatedByName = createdByName;
            jobSeekerCvLanguage.ModifiedByName = createdByName;
            await _jobSeekerCvLanguageDal.AddAsync(jobSeekerCvLanguage);
            return new SuccessResult(Messages.JobSeekerCvLanguage.jobSeekerCvLanguageAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvLanguageId, string modifiedByName)
        {
            var result = await _jobSeekerCvLanguageDal.AnyAsync(j => j.Id == jobSeekerCvLanguageId);
            if (result)
            {
                var jobSeekerCvLanguage = await _jobSeekerCvLanguageDal.GetAsync(j => j.Id == jobSeekerCvLanguageId);
                jobSeekerCvLanguage.IsActive = false;
                jobSeekerCvLanguage.ModifiedByName = modifiedByName;
                jobSeekerCvLanguage.ModifiedDate = DateTime.Now;
                await _jobSeekerCvLanguageDal.UpdateAsync(jobSeekerCvLanguage);
                return new SuccessResult(Messages.JobSeekerCvLanguage.jobSeekerCvLanguageDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvLanguage.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvLanguageListDto>> GetAllAsync()
        {
            var jobSeekerCvLanguages = await _jobSeekerCvLanguageDal.GetAllAsync(null, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguages.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvLanguageListDto>(new JobSeekerCvLanguageListDto
                {
                    JobSeekerCvLanguages = jobSeekerCvLanguages
                });
            }
            return new ErrorDataResult<JobSeekerCvLanguageListDto>(Messages.JobSeekerCvLanguage.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvLanguageListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvLanguages = await _jobSeekerCvLanguageDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguages.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvLanguageListDto>(new JobSeekerCvLanguageListDto
                {
                    JobSeekerCvLanguages = jobSeekerCvLanguages
                });
            }
            return new ErrorDataResult<JobSeekerCvLanguageListDto>(Messages.JobSeekerCvLanguage.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvLanguageListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvLanguages = await _jobSeekerCvLanguageDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguages.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvLanguageListDto>(new JobSeekerCvLanguageListDto
                {
                    JobSeekerCvLanguages = jobSeekerCvLanguages
                });
            }
            return new ErrorDataResult<JobSeekerCvLanguageListDto>(Messages.JobSeekerCvLanguage.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvLanguageDto>> GetAsync(int jobSeekerCvLanguageId)
        {
            var jobSeekerCvLanguage = await _jobSeekerCvLanguageDal.GetAsync(j => j.Id == jobSeekerCvLanguageId, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguage != null)
            {
                return new SuccessDataResult<JobSeekerCvLanguageDto>(new JobSeekerCvLanguageDto
                {
                    JobSeekerCvLanguage = jobSeekerCvLanguage
                });
            }
            return new ErrorDataResult<JobSeekerCvLanguageDto>(Messages.JobSeekerCvLanguage.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvLanguageId)
        {
            var result = await _jobSeekerCvLanguageDal.AnyAsync(j => j.Id == jobSeekerCvLanguageId);
            if (result)
            {
                var jobSeekerCvLanguage = await _jobSeekerCvLanguageDal.GetAsync(j => j.Id == jobSeekerCvLanguageId);
                await _jobSeekerCvLanguageDal.DeleteAsync(jobSeekerCvLanguage);
                return new SuccessResult(Messages.JobSeekerCvLanguage.jobSeekerCvLanguageHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvLanguage.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercvlanguage.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvLanguageValidator))]
        [CacheRemoveAspect("IJobSeekerCvLanguageService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvLanguageUpdateDto jobSeekerCvLanguageUpdateDto, string modifiedByName)
        {
            var oldJobSeekerCvLanguage = await _jobSeekerCvLanguageDal.GetAsync(j => j.Id == jobSeekerCvLanguageUpdateDto.Id);
            var jobSeekerCvLanguage = _mapper.Map<JobSeekerCvLanguageUpdateDto, JobSeekerCvLanguage>(jobSeekerCvLanguageUpdateDto, oldJobSeekerCvLanguage);
            jobSeekerCvLanguage.ModifiedByName = modifiedByName;
            await _jobSeekerCvLanguageDal.UpdateAsync(jobSeekerCvLanguage);
            return new SuccessResult(Messages.JobSeekerCvLanguage.jobSeekerCvLanguageUpdated);
        }
    }
}
