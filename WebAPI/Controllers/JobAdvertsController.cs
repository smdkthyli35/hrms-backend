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
    public class JobAdvertsController : ControllerBase
    {
        private readonly IJobAdvertService _jobAdvertService;

        public JobAdvertsController(IJobAdvertService jobAdvertService)
        {
            _jobAdvertService = jobAdvertService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobAdvertService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int jobAdvertId)
        {
            var result = await _jobAdvertService.GetAsync(jobAdvertId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobAdvert jobAdvert)
        {
            var result = await _jobAdvertService.AddAsync(jobAdvert, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobAdvert jobAdvert)
        {
            var result = await _jobAdvertService.UpdateAsync(jobAdvert, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int jobAdvertId)
        {
            var result = await _jobAdvertService.DeleteAsync(jobAdvertId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
