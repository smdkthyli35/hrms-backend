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
    public class JobSeekerCvEducationManager : IJobSeekerCvEducationService
    {
        private readonly IJobSeekerCvEducationDal _jobSeekerCvEducationDal;

        public JobSeekerCvEducationManager(IJobSeekerCvEducationDal jobSeekerCvEducationDal)
        {
            _jobSeekerCvEducationDal = jobSeekerCvEducationDal;
        }

        public async Task<IResult> AddAsync(JobSeekerCvEducation jobSeekerCvEducation, string createdByName)
        {
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

        public async Task<IDataResult<List<JobSeekerCvEducation>>> GetAllAsync()
        {
            var jobSeekerCvEducations = await _jobSeekerCvEducationDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekerCvEducations.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvEducation>>();
            }
            return new ErrorDataResult<List<JobSeekerCvEducation>>(Messages.JobSeekerCvEducation.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCvEducation>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvEducations = await _jobSeekerCvEducationDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv, j => j.JobSeekerCv);
            if (jobSeekerCvEducations.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvEducation>>();
            }
            return new ErrorDataResult<List<JobSeekerCvEducation>>(Messages.JobSeekerCvEducation.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCvEducation>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvEducations = await _jobSeekerCvEducationDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv, j => j.JobSeekerCv);
            if (jobSeekerCvEducations.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvEducation>>();
            }
            return new ErrorDataResult<List<JobSeekerCvEducation>>(Messages.JobSeekerCvEducation.NotFound(isPlural: true));
        }

        public async Task<IDataResult<JobSeekerCvEducation>> GetAsync(int jobSeekerCvEducationId)
        {
            var jobSeekerCvEducation = await _jobSeekerCvEducationDal.GetAsync(j => j.Id == jobSeekerCvEducationId, j => j.JobSeekerCv);
            if (jobSeekerCvEducation != null)
            {
                return new SuccessDataResult<JobSeekerCvEducation>();
            }
            return new ErrorDataResult<JobSeekerCvEducation>();
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

        public async Task<IResult> UpdateAsync(JobSeekerCvEducation jobSeekerCvEducation, string modifiedByName)
        {
            var oldjobSeekerCvEducation = await _jobSeekerCvEducationDal.GetAsync(j => j.Id == jobSeekerCvEducation.Id);
            oldjobSeekerCvEducation.ModifiedByName = modifiedByName;
            var updatedjobSeekerCvEducation = await _jobSeekerCvEducationDal.UpdateAsync(oldjobSeekerCvEducation);
            return new SuccessResult(Messages.JobSeekerCvEducation.jobSeekerCvEducationUpdated);
        }
    }
}
