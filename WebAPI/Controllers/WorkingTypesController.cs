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
    public class WorkingTypesController : ControllerBase
    {
        private readonly IWorkingTypeService _workingTypeService;

        public WorkingTypesController(IWorkingTypeService workingTypeService)
        {
            _workingTypeService = workingTypeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _workingTypeService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int workingTypeId)
        {
            var result = await _workingTypeService.GetAsync(workingTypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(WorkingTypeAddDto workingTypeAddDto)
        {
            var result = await _workingTypeService.AddAsync(workingTypeAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(WorkingTypeUpdateDto workingTypeUpdateDto)
        {
            var result = await _workingTypeService.UpdateAsync(workingTypeUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int workingTypeId)
        {
            var result = await _workingTypeService.DeleteAsync(workingTypeId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("harddelete")]
        public async Task<IActionResult> HardDelete(int workingTypeId)
        {
            var result = await _workingTypeService.HardDeleteAsync(workingTypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
