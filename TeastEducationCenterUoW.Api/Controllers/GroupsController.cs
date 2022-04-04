using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Groups;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationUow.Service.DTOs.Groups;
using TestEducationUow.Service.Interfaces;

namespace TeastEducationCenterUoW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Group>>> Create([FromForm] GroupForCreationDto grouptDto)
        {
            var result = await groupService.CreateAsync(grouptDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);

        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Group>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await groupService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Group>>> Get([FromRoute] Guid id)
        {
            var result = await groupService.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Group>>> Update(Guid id, [FromForm] GroupForCreationDto groupDto)
        {
            var result = await groupService.UpdateAsync(id, groupDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await groupService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
