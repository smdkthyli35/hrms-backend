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
    public class JobSeekerCvEducationsController : ControllerBase
    {
        private readonly IJobSeekerCvEducationService _jobSeekerCvEducationService;

        public JobSeekerCvEducationsController(IJobSeekerCvEducationService jobSeekerCvEducationService)
        {
            _jobSeekerCvEducationService = jobSeekerCvEducationService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvEducationService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvEducationId)
        {
            var result = await _jobSeekerCvEducationService.GetAsync(jobSeekerCvEducationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvEducation jobSeekerCvEducation)
        {
            var result = await _jobSeekerCvEducationService.AddAsync(jobSeekerCvEducation, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvEducation jobSeekerCvEducation)
        {
            var result = await _jobSeekerCvEducationService.UpdateAsync(jobSeekerCvEducation, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvEducationId)
        {
            var result = await _jobSeekerCvEducationService.DeleteAsync(jobSeekerCvEducationId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
