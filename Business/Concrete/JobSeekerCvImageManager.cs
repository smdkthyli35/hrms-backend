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
    public class JobSeekerCvImageManager : IJobSeekerCvImageService
    {
        private readonly IJobSeekerCvImageDal _jobSeekerCvImageDal;

        public JobSeekerCvImageManager(IJobSeekerCvImageDal jobSeekerCvImageDal)
        {
            _jobSeekerCvImageDal = jobSeekerCvImageDal;
        }

        public async Task<IResult> AddAsync(JobSeekerCvImage jobSeekerCvImage, string createdByName)
        {
            jobSeekerCvImage.CreatedByName = createdByName;
            jobSeekerCvImage.ModifiedByName = createdByName;
            await _jobSeekerCvImageDal.AddAsync(jobSeekerCvImage);
            return new SuccessResult(Messages.JobSeekerCvImage.jobSeekerCvImageAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvImageId, string modifiedByName)
        {
            var result = await _jobSeekerCvImageDal.AnyAsync(j => j.Id == jobSeekerCvImageId);
            if (result)
            {
                var jobSeekerCvImage = await _jobSeekerCvImageDal.GetAsync(j => j.Id == jobSeekerCvImageId);
                jobSeekerCvImage.IsActive = false;
                jobSeekerCvImage.ModifiedByName = modifiedByName;
                jobSeekerCvImage.ModifiedDate = DateTime.Now;
                await _jobSeekerCvImageDal.UpdateAsync(jobSeekerCvImage);
                return new SuccessResult(Messages.JobSeekerCvImage.jobSeekerCvImageDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvImage.NotFound(isPlural: false));
        }

        public async Task<IDataResult<List<JobSeekerCvImage>>> GetAllAsync()
        {
            var jobSeekerCvImages = await _jobSeekerCvImageDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekerCvImages.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvImage>>();
            }
            return new ErrorDataResult<List<JobSeekerCvImage>>(Messages.JobSeekerCvImage.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCvImage>>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvImages = await _jobSeekerCvImageDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv);
            if (jobSeekerCvImages.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvImage>>();
            }
            return new ErrorDataResult<List<JobSeekerCvImage>>(Messages.JobSeekerCvImage.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<JobSeekerCvImage>>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvImages = await _jobSeekerCvImageDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv);
            if (jobSeekerCvImages.Count > -1)
            {
                return new SuccessDataResult<List<JobSeekerCvImage>>();
            }
            return new ErrorDataResult<List<JobSeekerCvImage>>(Messages.JobSeekerCvImage.NotFound(isPlural: true));
        }

        public async Task<IDataResult<JobSeekerCvImage>> GetAsync(int jobSeekerCvImageId)
        {
            var jobSeekerCvImage = await _jobSeekerCvImageDal.GetAsync(j => j.Id == jobSeekerCvImageId, j => j.JobSeekerCv);
            if (jobSeekerCvImage != null)
            {
                return new SuccessDataResult<JobSeekerCvImage>();
            }
            return new ErrorDataResult<JobSeekerCvImage>();
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvImageId)
        {
            var result = await _jobSeekerCvImageDal.AnyAsync(j => j.Id == jobSeekerCvImageId);
            if (result)
            {
                var jobSeekerCvImage = await _jobSeekerCvImageDal.GetAsync(j => j.Id == jobSeekerCvImageId);
                await _jobSeekerCvImageDal.DeleteAsync(jobSeekerCvImage);
                return new SuccessResult(Messages.JobSeekerCvImage.jobSeekerCvImageHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvImage.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(JobSeekerCvImage jobSeekerCvImage, string modifiedByName)
        {
            var oldjobSeekerCvImage = await _jobSeekerCvImageDal.GetAsync(j => j.Id == jobSeekerCvImage.Id);
            oldjobSeekerCvImage.ModifiedByName = modifiedByName;
            var updatedJobSeekerCvImage = await _jobSeekerCvImageDal.UpdateAsync(oldjobSeekerCvImage);
            return new SuccessResult(Messages.JobSeekerCvImage.jobSeekerCvImageUpdated);
        }
    }
}
