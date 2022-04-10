using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationUow.Service.DTOs.Courses;
using TestEducationUow.Service.Interfaces;

namespace TeastEducationCenterUoW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseForCreationDto coursetDto)
        {
            var result = await courseService.CreateAsync(coursetDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await courseService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await courseService.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] CourseForCreationDto coursetDto)
        {
            var result = await courseService.UpdateAsync(id, coursetDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await courseService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
