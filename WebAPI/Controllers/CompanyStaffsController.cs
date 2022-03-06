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
    public class CompanyStaffsController : ControllerBase
    {
        private readonly ICompanyStaffService _companyStaffService;

        public CompanyStaffsController(ICompanyStaffService companyStaffService)
        {
            _companyStaffService = companyStaffService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyStaffService.GetAllByNonDeletedAndActiveAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int companyStaffId)
        {
            var result = await _companyStaffService.GetAsync(companyStaffId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CompanyStaffAddDto companyStaffAddDto)
        {
            var result = await _companyStaffService.AddAsync(companyStaffAddDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CompanyStaffUpdateDto companyStaffUpdateDto)
        {
            var result = await _companyStaffService.UpdateAsync(companyStaffUpdateDto, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int companyStaffId)
        {
            var result = await _companyStaffService.DeleteAsync(companyStaffId, "Samed Kütahyalı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
