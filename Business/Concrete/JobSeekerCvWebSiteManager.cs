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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobSeekerCvWebSiteManager : IJobSeekerCvWebSiteService
    {
        private readonly IJobSeekerCvWebSiteDal _jobSeekerCvWebSiteDal;

        public JobSeekerCvWebSiteManager(IJobSeekerCvWebSiteDal jobSeekerCvWebSiteDal)
        {
            _jobSeekerCvWebSiteDal = jobSeekerCvWebSiteDal;
        }

        [SecuredOperation("jobseekercvwebsite.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvWebSiteValidator))]
        [CacheRemoveAspect("IJobSeekerCvWebSiteService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvWebSite jobSeekerCvWebSite, string createdByName)
        {
            jobSeekerCvWebSite.CreatedByName = createdByName;
            jobSeekerCvWebSite.ModifiedByName = createdByName;
            await _jobSeekerCvWebSiteDal.AddAsync(jobSeekerCvWebSite);
            return new SuccessResult(Messages.JobSeekerCvWebSite.jobSeekerCvWebSiteAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvWebSiteId, string modifiedByName)
        {
            var result = await _jobSeekerCvWebSiteDal.AnyAsync(j => j.Id == jobSeekerCvWebSiteId);
            if (result)
            {
                var jobSeekerCvWebSite = await _jobSeekerCvWebSiteDal.GetAsync(j => j.Id == jobSeekerCvWebSiteId);
                jobSeekerCvWebSite.IsActive = false;
                jobSeekerCvWebSite.ModifiedByName = modifiedByName;
                jobSeekerCvWebSite.ModifiedDate = DateTime.Now;
                await _jobSeekerCvWebSiteDal.UpdateAsync(jobSeekerCvWebSite);
                return new SuccessResult(Messages.JobSeekerCvWebSite.jobSeekerCvWebSiteDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvWebSite.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvWebSite>>> GetAllAsync()
        {
            var jobSeekerCvWebSites = await _jobSeekerCvWebSiteDal.GetAllAsync(null, j => j.JobSeekerCv, j => j.WebSite);
            if (jobSeekerCvWebSites.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvWebSite>>();
            }
            return new ErrorDataResult<List<JobSeekerCvWebSite>>(Messages.JobSeekerCvWebSite.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvWebSite>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvWebSites = await _jobSeekerCvWebSiteDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.WebSite);
            if (jobSeekerCvWebSites.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvWebSite>>();
            }
            return new ErrorDataResult<List<JobSeekerCvWebSite>>(Messages.JobSeekerCvWebSite.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<JobSeekerCvWebSite>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvWebSites = await _jobSeekerCvWebSiteDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.WebSite);
            if (jobSeekerCvWebSites.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvWebSite>>();
            }
            return new ErrorDataResult<List<JobSeekerCvWebSite>>(Messages.JobSeekerCvWebSite.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvWebSite>> GetAsync(int jobSeekerCvWebSiteId)
        {
            var jobSeekerCvWebSite = await _jobSeekerCvWebSiteDal.GetAsync(j => j.Id == jobSeekerCvWebSiteId, j => j.JobSeekerCv, j => j.WebSite);
            if (jobSeekerCvWebSite != null)
            {
                return new SuccessDataResult<JobSeekerCvWebSite>();
            }
            return new ErrorDataResult<JobSeekerCvWebSite>();
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvWebSiteId)
        {
            var result = await _jobSeekerCvWebSiteDal.AnyAsync(j => j.Id == jobSeekerCvWebSiteId);
            if (result)
            {
                var jobSeekerCvWebSite = await _jobSeekerCvWebSiteDal.GetAsync(j => j.Id == jobSeekerCvWebSiteId);
                await _jobSeekerCvWebSiteDal.DeleteAsync(jobSeekerCvWebSite);
                return new SuccessResult(Messages.JobSeekerCvWebSite.jobSeekerCvWebSiteHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvWebSite.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercvwebsite.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvWebSiteValidator))]
        [CacheRemoveAspect("IJobSeekerCvWebSiteService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvWebSite jobSeekerCvWebSite, string modifiedByName)
        {
            var oldjobSeekerCvWebSite = await _jobSeekerCvWebSiteDal.GetAsync(j => j.Id == jobSeekerCvWebSite.Id);
            oldjobSeekerCvWebSite.ModifiedByName = modifiedByName;
            var updatedJobSeekerCvWebSite = await _jobSeekerCvWebSiteDal.UpdateAsync(oldjobSeekerCvWebSite);
            return new SuccessResult(Messages.JobSeekerCvWebSite.jobSeekerCvWebSiteUpdated);
        }
    }
}
