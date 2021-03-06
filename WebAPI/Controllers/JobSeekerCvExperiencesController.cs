using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        [HttpGet("getlistbyjobseekercv")]
        public async Task<IActionResult> GetListByJobSeekerCv(int jobSeekerCvId)
        {
            var result = await _jobSeekerCvExperienceService.GetListByJobSeekerCvAsync(jobSeekerCvId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvExperienceAddDto jobSeekerCvExperienceAddDto)
        {
            var result = await _jobSeekerCvExperienceService.AddAsync(jobSeekerCvExperienceAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvExperienceUpdateDto jobSeekerCvExperienceUpdateDto)
        {
            var result = await _jobSeekerCvExperienceService.UpdateAsync(jobSeekerCvExperienceUpdateDto, "Samed Kütahyalı");
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

        [HttpPost("harddelete")]
        public async Task<IActionResult> HardDelete(int jobSeekerCvExperienceId)
        {
            var result = await _jobSeekerCvExperienceService.HardDeleteAsync(jobSeekerCvExperienceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
