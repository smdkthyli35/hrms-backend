using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerCvExperiencesController : ControllerBase
    {
        private readonly IJobSeekerCvExperienceService _jobSeekerCvExperienceService;

        public JobSeekerCvExperiencesController(IJobSeekerCvExperienceService jobSeekerCvExperienceService)
        {
            _jobSeekerCvExperienceService = jobSeekerCvExperienceService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvExperienceService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvExperienceId)
        {
            var result = await _jobSeekerCvExperienceService.GetAsync(jobSeekerCvExperienceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvExperience jobSeekerCvExperience)
        {
            var result = await _jobSeekerCvExperienceService.AddAsync(jobSeekerCvExperience, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvExperience jobSeekerCvExperience)
        {
            var result = await _jobSeekerCvExperienceService.UpdateAsync(jobSeekerCvExperience, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvExperienceId)
        {
            var result = await _jobSeekerCvExperienceService.DeleteAsync(jobSeekerCvExperienceId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
