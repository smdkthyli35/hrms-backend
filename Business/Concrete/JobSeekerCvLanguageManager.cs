using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class JobSeekerCvLanguageManager : IJobSeekerCvLanguageService
    {
        private readonly IJobSeekerCvLanguageDal _jobSeekerCvLanguageDal;

        public JobSeekerCvLanguageManager(IJobSeekerCvLanguageDal jobSeekerCvLanguageDal)
        {
            _jobSeekerCvLanguageDal = jobSeekerCvLanguageDal;
        }

        [ValidationAspect(typeof(JobSeekerCvLanguageValidator))]
        [CacheRemoveAspect("IJobSeekerCvLanguageService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvLanguage jobSeekerCvLanguage, string createdByName)
        {
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

        public async Task<IDataResult<List<JobSeekerCvLanguage>>> GetAllAsync()
        {
            var jobSeekerCvLanguages = await _jobSeekerCvLanguageDal.GetAllAsync(null, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguages.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvLanguage>>();
            }
            return new ErrorDataResult<List<JobSeekerCvLanguage>>(Messages.JobSeekerCvLanguage.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCvLanguage>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvLanguages = await _jobSeekerCvLanguageDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguages.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvLanguage>>();
            }
            return new ErrorDataResult<List<JobSeekerCvLanguage>>(Messages.JobSeekerCvLanguage.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCvLanguage>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvLanguages = await _jobSeekerCvLanguageDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguages.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvLanguage>>();
            }
            return new ErrorDataResult<List<JobSeekerCvLanguage>>(Messages.JobSeekerCvLanguage.NotFound(isPlural: true));
        }

        public async Task<IDataResult<JobSeekerCvLanguage>> GetAsync(int jobSeekerCvLanguageId)
        {
            var jobSeekerCvLanguage = await _jobSeekerCvLanguageDal.GetAsync(j => j.Id == jobSeekerCvLanguageId, j => j.JobSeekerCv, j => j.Language);
            if (jobSeekerCvLanguage != null)
            {
                return new SuccessDataResult<JobSeekerCvLanguage>();
            }
            return new ErrorDataResult<JobSeekerCvLanguage>();
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

        [ValidationAspect(typeof(JobSeekerCvLanguageValidator))]
        [CacheRemoveAspect("IJobSeekerCvLanguageService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvLanguage jobSeekerCvLanguage, string modifiedByName)
        {
            var oldJobSeekerCvLanguage = await _jobSeekerCvLanguageDal.GetAsync(j => j.Id == jobSeekerCvLanguage.Id);
            oldJobSeekerCvLanguage.ModifiedByName = modifiedByName;
            var updatedJobSeekerCvLanguage = await _jobSeekerCvLanguageDal.UpdateAsync(oldJobSeekerCvLanguage);
            return new SuccessResult(Messages.JobSeekerCvLanguage.jobSeekerCvLanguageUpdated);
        }
    }
}
