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
    public class JobSeekerCvsController : ControllerBase
    {
        private readonly IJobSeekerCvService _jobSeekerCvService;

        public JobSeekerCvsController(IJobSeekerCvService jobSeekerCvService)
        {
            _jobSeekerCvService = jobSeekerCvService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvId)
        {
            var result = await _jobSeekerCvService.GetAsync(jobSeekerCvId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvAddDto jobSeekerCvAddDto)
        {
            var result = await _jobSeekerCvService.AddAsync(jobSeekerCvAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvUpdateDto jobSeekerCvUpdateDto)
        {
            var result = await _jobSeekerCvService.UpdateAsync(jobSeekerCvUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvId)
        {
            var result = await _jobSeekerCvService.DeleteAsync(jobSeekerCvId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
