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
    public class JobSeekerCvSkillManager : IJobSeekerCvSkillService
    {
        private readonly IJobSeekerCvSkillDal _jobSeekerCvSkillDal;
        private readonly IMapper _mapper;

        public JobSeekerCvSkillManager(IJobSeekerCvSkillDal jobSeekerCvSkillDal, IMapper mapper)
        {
            _jobSeekerCvSkillDal = jobSeekerCvSkillDal;
            _mapper = mapper;
        }

        [SecuredOperation("jobseekercvskill.add,admin")]
        [ValidationAspect(typeof(JobSeekerCvSkillValidator))]
        [CacheRemoveAspect("IJobSeekerCvSkillService.Get")]
        public async Task<IResult> AddAsync(JobSeekerCvSkillAddDto jobSeekerCvSkillAddDto, string createdByName)
        {
            var jobSeekerCvSkill = _mapper.Map<JobSeekerCvSkill>(jobSeekerCvSkillAddDto);
            jobSeekerCvSkill.CreatedByName = createdByName;
            jobSeekerCvSkill.ModifiedByName = createdByName;
            await _jobSeekerCvSkillDal.AddAsync(jobSeekerCvSkill);
            return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillAdded);
        }

        public async Task<IResult> DeleteAsync(int jobSeekerCvSkillId, string modifiedByName)
        {
            var result = await _jobSeekerCvSkillDal.AnyAsync(j => j.Id == jobSeekerCvSkillId);
            if (result)
            {
                var jobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillId);
                jobSeekerCvSkill.IsActive = false;
                jobSeekerCvSkill.ModifiedByName = modifiedByName;
                jobSeekerCvSkill.ModifiedDate = DateTime.Now;
                await _jobSeekerCvSkillDal.UpdateAsync(jobSeekerCvSkill);
                return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillDeleted);
            }
            return new ErrorResult(Messages.JobSeekerCvSkill.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvSkillListDto>> GetAllAsync()
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetAllAsync(null, j => j.JobSeekerCv);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvSkillListDto>(new JobSeekerCvSkillListDto
                {
                    JobSeekerCvSkills = jobSeekerCvSkills
                });
            }
            return new ErrorDataResult<JobSeekerCvSkillListDto>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvSkillListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetAllAsync(j => !j.IsDeleted && j.IsActive, j => j.JobSeekerCv);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvSkillListDto>(new JobSeekerCvSkillListDto
                {
                    JobSeekerCvSkills = jobSeekerCvSkills
                });
            }
            return new ErrorDataResult<JobSeekerCvSkillListDto>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvSkillListDto>> GetAllByNonDeletedAsync()
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetAllAsync(j => !j.IsDeleted, j => j.JobSeekerCv);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvSkillListDto>(new JobSeekerCvSkillListDto
                {
                    JobSeekerCvSkills = jobSeekerCvSkills
                });
            }
            return new ErrorDataResult<JobSeekerCvSkillListDto>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<JobSeekerCvSkillDto>> GetAsync(int jobSeekerCvSkillId)
        {
            var jobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillId, j => j.JobSeekerCv);
            if (jobSeekerCvSkill != null)
            {
                return new SuccessDataResult<JobSeekerCvSkillDto>(new JobSeekerCvSkillDto
                {
                    JobSeekerCvSkill = jobSeekerCvSkill
                });
            }
            return new ErrorDataResult<JobSeekerCvSkillDto>(Messages.JobSeekerCvSkill.NotFound(isPlural: false));
        }

        public async Task<IDataResult<JobSeekerCvSkillListDto>> GetListByJobSeekerCvAsync(int jobSeekerCvId)
        {
            var jobSeekerCvSkills = await _jobSeekerCvSkillDal.GetListByJobSeekerCvId(jobSeekerCvId);
            if (jobSeekerCvSkills.Count > -1)
            {
                return new SuccessDataResult<JobSeekerCvSkillListDto>(new JobSeekerCvSkillListDto
                {
                    JobSeekerCvSkills = jobSeekerCvSkills
                });
            }
            return new ErrorDataResult<JobSeekerCvSkillListDto>(Messages.JobSeekerCvSkill.NotFound(isPlural: true));
        }

        public async Task<IResult> HardDeleteAsync(int jobSeekerCvSkillId)
        {
            var result = await _jobSeekerCvSkillDal.AnyAsync(j => j.Id == jobSeekerCvSkillId);
            if (result)
            {
                var jobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillId);
                await _jobSeekerCvSkillDal.DeleteAsync(jobSeekerCvSkill);
                return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillHardDeleted);
            }
            return new SuccessResult(Messages.JobSeekerCvSkill.NotFound(isPlural: false));
        }

        [SecuredOperation("jobseekercvskill.update,admin")]
        [ValidationAspect(typeof(JobSeekerCvSkillValidator))]
        [CacheRemoveAspect("IJobSeekerCvSkillService.Get")]
        public async Task<IResult> UpdateAsync(JobSeekerCvSkillUpdateDto jobSeekerCvSkillUpdateDto, string modifiedByName)
        {
            var oldJobSeekerCvSkill = await _jobSeekerCvSkillDal.GetAsync(j => j.Id == jobSeekerCvSkillUpdateDto.Id);
            var jobSeekerCvSkill = _mapper.Map<JobSeekerCvSkillUpdateDto, JobSeekerCvSkill>(jobSeekerCvSkillUpdateDto, oldJobSeekerCvSkill);
            jobSeekerCvSkill.ModifiedByName = modifiedByName;
            await _jobSeekerCvSkillDal.UpdateAsync(jobSeekerCvSkill);
            return new SuccessResult(Messages.JobSeekerCvSkill.jobSeekerCvSkillUpdated);
        }
    }
}
