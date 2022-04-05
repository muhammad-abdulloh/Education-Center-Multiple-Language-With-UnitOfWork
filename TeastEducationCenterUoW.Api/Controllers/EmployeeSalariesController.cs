using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Departments;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationUow.Service.DTOs.Departaments;
using TestEducationUow.Service.Interfaces;

namespace TeastEducationCenterUoW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalariesController : ControllerBase
    {
        private readonly IEmployeeSalaryService employeeSalaryService;

        public EmployeeSalariesController(IEmployeeSalaryService employeeSalaryService)
        {
            this.employeeSalaryService = employeeSalaryService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<EmployeeSalary>>> Create(EmployeeSalaryForCreationDto employeeDto)
        {
            var result = await employeeSalaryService.CreateAsync(employeeDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);

        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<EmployeeSalary>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await employeeSalaryService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<EmployeeSalary>>> Get([FromRoute] Guid id)
        {
            var result = await employeeSalaryService.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<EmployeeSalary>>> Update(Guid id, [FromForm] EmployeeSalaryForCreationDto employeeSalaryDto)
        {
            var result = await employeeSalaryService.UpdateAsync(id, employeeSalaryDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await employeeSalaryService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
