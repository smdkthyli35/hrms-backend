using Business.Abstract;
using Business.Constants;
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
    public class JobSeekerCvManager : IJobSeekerCvService
    {
        private readonly IJobSeekerCvDal _jobSeekerCvDal;

        public JobSeekerCvManager(IJobSeekerCvDal jobSeekerCvDal)
        {
            _jobSeekerCvDal = jobSeekerCvDal;
        }

        public async Task<IResult> AddAsync(JobSeekerCv jobSeekerCv, string createdByName)
        {
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

        public async Task<IDataResult<List<JobSeekerCv>>> GetAllAsync()
        {
            var jobSeekerCvs = await _jobSeekerCvDal.GetAllAsync(null, j => j.JobSeeker);
            if (jobSeekerCvs.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCv>>();
            }
            return new ErrorDataResult<List<JobSeekerCv>>(Messages.JobSeekerCv.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCv>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvs = await _jobSeekerCvDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeeker);
            if (jobSeekerCvs.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCv>>();
            }
            return new ErrorDataResult<List<JobSeekerCv>>(Messages.JobSeekerCv.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCv>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvs = await _jobSeekerCvDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeeker);
            if (jobSeekerCvs.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCv>>();
            }
            return new ErrorDataResult<List<JobSeekerCv>>(Messages.JobSeekerCv.NotFound(isPlural: true));
        }

        public async Task<IDataResult<JobSeekerCv>> GetAsync(int jobSeekerCvId)
        {
            var jobSeekerCv = await _jobSeekerCvDal.GetAsync(j => j.Id == jobSeekerCvId, j => j.JobSeeker);
            if (jobSeekerCv != null)
            {
                return new SuccessDataResult<JobSeekerCv>();
            }
            return new ErrorDataResult<JobSeekerCv>();
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

        public async Task<IResult> UpdateAsync(JobSeekerCv jobSeekerCv, string modifiedByName)
        {
            var oldjobSeekerCv = await _jobSeekerCvDal.GetAsync(j => j.Id == jobSeekerCv.Id);
            oldjobSeekerCv.ModifiedByName = modifiedByName;
            var updatedjobSeekerCv = await _jobSeekerCvDal.UpdateAsync(oldjobSeekerCv);
            return new SuccessResult(Messages.JobSeekerCv.jobSeekerCvHardDeleted);
        }
    }
}
