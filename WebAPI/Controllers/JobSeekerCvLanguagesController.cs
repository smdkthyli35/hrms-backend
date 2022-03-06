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
    public class JobSeekerCvLanguagesController : ControllerBase
    {
        private readonly IJobSeekerCvLanguageService _jobSeekerCvLanguageService;

        public JobSeekerCvLanguagesController(IJobSeekerCvLanguageService jobSeekerCvLanguageService)
        {
            _jobSeekerCvLanguageService = jobSeekerCvLanguageService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvLanguageService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvLanguageId)
        {
            var result = await _jobSeekerCvLanguageService.GetAsync(jobSeekerCvLanguageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getlistbyjobseekercv")]
        public async Task<IActionResult> GetListByJobSeekerCv(int jobSeekerCvId)
        {
            var result = await _jobSeekerCvLanguageService.GetListByJobSeekerCvAsync(jobSeekerCvId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvLanguageAddDto jobSeekerCvLanguageAddDto)
        {
            var result = await _jobSeekerCvLanguageService.AddAsync(jobSeekerCvLanguageAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvLanguageUpdateDto jobSeekerCvLanguageUpdateDto)
        {
            var result = await _jobSeekerCvLanguageService.UpdateAsync(jobSeekerCvLanguageUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvLanguageId)
        {
            var result = await _jobSeekerCvLanguageService.DeleteAsync(jobSeekerCvLanguageId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("harddelete")]
        public async Task<IActionResult> HardDelete(int jobSeekerCvLanguageId)
        {
            var result = await _jobSeekerCvLanguageService.HardDeleteAsync(jobSeekerCvLanguageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
