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
    public class JobSeekerCvSkillsController : ControllerBase
    {
        private readonly IJobSeekerCvSkillService _jobSeekerCvSkillService;

        public JobSeekerCvSkillsController(IJobSeekerCvSkillService jobSeekerCvSkillService)
        {
            _jobSeekerCvSkillService = jobSeekerCvSkillService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvSkillService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvSkillId)
        {
            var result = await _jobSeekerCvSkillService.GetAsync(jobSeekerCvSkillId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvSkillAddDto jobSeekerCvSkillAddDto)
        {
            var result = await _jobSeekerCvSkillService.AddAsync(jobSeekerCvSkillAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvSkillUpdateDto jobSeekerCvSkillUpdateDto)
        {
            var result = await _jobSeekerCvSkillService.UpdateAsync(jobSeekerCvSkillUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvSkillId)
        {
            var result = await _jobSeekerCvSkillService.DeleteAsync(jobSeekerCvSkillId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
