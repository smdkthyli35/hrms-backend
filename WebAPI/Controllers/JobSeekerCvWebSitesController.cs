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
    public class JobSeekerCvWebSitesController : ControllerBase
    {
        private readonly IJobSeekerCvWebSiteService _jobSeekerCvWebSiteService;

        public JobSeekerCvWebSitesController(IJobSeekerCvWebSiteService jobSeekerCvWebSiteService)
        {
            _jobSeekerCvWebSiteService = jobSeekerCvWebSiteService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvWebSiteService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvWebSiteId)
        {
            var result = await _jobSeekerCvWebSiteService.GetAsync(jobSeekerCvWebSiteId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvWebSiteAddDto jobSeekerCvWebSiteAddDto)
        {
            var result = await _jobSeekerCvWebSiteService.AddAsync(jobSeekerCvWebSiteAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvWebSiteUpdateDto jobSeekerCvWebSiteUpdateDto)
        {
            var result = await _jobSeekerCvWebSiteService.UpdateAsync(jobSeekerCvWebSiteUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvWebSiteId)
        {
            var result = await _jobSeekerCvWebSiteService.DeleteAsync(jobSeekerCvWebSiteId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
