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
    public class WorkingTimesController : ControllerBase
    {
        private readonly IWorkingTimeService _workingTimeService;

        public WorkingTimesController(IWorkingTimeService workingTimeService)
        {
            _workingTimeService = workingTimeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _workingTimeService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int workingTimeId)
        {
            var result = await _workingTimeService.GetAsync(workingTimeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(WorkingTimeAddDto workingTimeAddDto)
        {
            var result = await _workingTimeService.AddAsync(workingTimeAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(WorkingTimeUpdateDto workingTimeUpdateDto)
        {
            var result = await _workingTimeService.UpdateAsync(workingTimeUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int workingTimeId)
        {
            var result = await _workingTimeService.DeleteAsync(workingTimeId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("harddelete")]
        public async Task<IActionResult> HardDelete(int workingTimeId)
        {
            var result = await _workingTimeService.HardDeleteAsync(workingTimeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
