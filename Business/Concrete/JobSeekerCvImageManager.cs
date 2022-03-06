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
    public class JobSeekerCvImageManager : IJobSeekerCvImageService
    {
        private readonly IJobSeekerCvImageDal _jobSeekerCvImageDal;
        private readonly IMapper _mapper;

        public JobSeekerCvImageManager(IJobSeekerCvImageDal jobSeekerCvImageDal, IMapper mapper)
        {
            _jobSeekerCvImageDal = jobSeekerCvImageDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseekercvimage.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvImageValidator))]
        [CacheRemoveAspect("IJobSeekerCvImageService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvImageAddDto jobSeekerCvImageAddDto, string createdByName)
        {
            var jobSeekerCvImage = _mapper.Map<JobSeekerCvImage>(jobSeekerCvImageAddDto);
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

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvImageListDto>> GetAllAsync()
        {
            var jobSeekerCvImages = await _jobSeekerCvImageDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekerCvImages.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvImageListDto>(new JobSeekerCvImageListDto
                {
                    JobSeekerCvImages = jobSeekerCvImages
                });
            }
            return new ErrorDataResult<JobSeekerCvImageListDto>(Messages.JobSeekerCvImage.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvImageListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvImages = await _jobSeekerCvImageDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv);
            if (jobSeekerCvImages.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvImageListDto>(new JobSeekerCvImageListDto
                {
                    JobSeekerCvImages = jobSeekerCvImages
                });
            }
            return new ErrorDataResult<JobSeekerCvImageListDto>(Messages.JobSeekerCvImage.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvImageListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvImages = await _jobSeekerCvImageDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv);
            if (jobSeekerCvImages.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvImageListDto>(new JobSeekerCvImageListDto
                {
                    JobSeekerCvImages = jobSeekerCvImages
                });
            }
            return new ErrorDataResult<JobSeekerCvImageListDto>(Messages.JobSeekerCvImage.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvImageDto>> GetAsync(int jobSeekerCvImageId)
        {
            var jobSeekerCvImage = await _jobSeekerCvImageDal.GetAsync(j => j.Id == jobSeekerCvImageId, j => j.JobSeekerCv);
            if (jobSeekerCvImage != null)
            {
                return new SuccessDataResult<JobSeekerCvImageDto>(new JobSeekerCvImageDto
                {
                    JobSeekerCvImage = jobSeekerCvImage
                });
            }
            return new ErrorDataResult<JobSeekerCvImageDto>(Messages.JobSeekerCvImage.NotFound(isPlural: false));
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

        [SecuredOperation("jobseekercvimage.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvImageValidator))]
        [CacheRemoveAspect("IJobSeekerCvImageService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvImageUpdateDto jobSeekerCvImageUpdateDto, string modifiedByName)
        {
            var oldJobSeekerCvImage = await _jobSeekerCvImageDal.GetAsync(j => j.Id == jobSeekerCvImageUpdateDto.Id);
            var jobSeekerCvImage = _mapper.Map<JobSeekerCvImageUpdateDto, JobSeekerCvImage>(jobSeekerCvImageUpdateDto, oldJobSeekerCvImage);
            jobSeekerCvImage.ModifiedByName = modifiedByName;
            await _jobSeekerCvImageDal.UpdateAsync(jobSeekerCvImage);
            return new SuccessResult(Messages.JobSeekerCvImage.jobSeekerCvImageUpdated);
        }
    }
}
