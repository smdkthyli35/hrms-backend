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
    public class JobSeekerCvImagesController : ControllerBase
    {
        private readonly IJobSeekerCvImageService _jobSeekerCvImageService;

        public JobSeekerCvImagesController(IJobSeekerCvImageService jobSeekerCvImageService)
        {
            _jobSeekerCvImageService = jobSeekerCvImageService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobSeekerCvImageService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobSeekerCvImageId)
        {
            var result = await _jobSeekerCvImageService.GetAsync(jobSeekerCvImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobSeekerCvImage jobSeekerCvImage)
        {
            var result = await _jobSeekerCvImageService.AddAsync(jobSeekerCvImage, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobSeekerCvImage jobSeekerCvImage)
        {
            var result = await _jobSeekerCvImageService.UpdateAsync(jobSeekerCvImage, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobSeekerCvImageId)
        {
            var result = await _jobSeekerCvImageService.DeleteAsync(jobSeekerCvImageId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
