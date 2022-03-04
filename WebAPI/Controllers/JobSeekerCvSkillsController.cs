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
        public async Task<IActionResult> Add(JobSeekerCvSkill jobSeekerCvSkill)
        {
            var result = await _jobSeekerCvSkillService.AddAsync(jobSeekerCvSkill, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvSkill jobSeekerCvSkill)
        {
            var result = await _jobSeekerCvSkillService.UpdateAsync(jobSeekerCvSkill, "Samed Kütahyalı");
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
