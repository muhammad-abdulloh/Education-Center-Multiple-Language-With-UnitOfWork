using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationUow.Domain.Entities.Departments;
using TestEducationUow.Service.DTOs.Departaments;
using TestEducationUow.Service.Interfaces;

namespace TeastEducationCenterUoW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Employee>>> Create([FromForm] EmployeeForCreationDto employeeDto)
        {
            var result = await employeeService.CreateAsync(employeeDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);

        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Employee>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await employeeService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Employee>>> Get([FromRoute] Guid id)
        {
            var result = await employeeService.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Employee>>> Update(Guid id, [FromForm] EmployeeForCreationDto employeeDto)
        {
            var result = await employeeService.UpdateAsync(id, employeeDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await employeeService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
