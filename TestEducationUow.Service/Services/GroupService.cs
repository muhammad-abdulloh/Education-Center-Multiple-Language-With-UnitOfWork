using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Groups;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationUow.Service.DTOs.Groups;
using TestEducationUow.Service.Interfaces;

namespace TestEducationUow.Service.Services
{
    public class GroupService : IGroupService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<Group>> CreateAsync(GroupForCreationDto groupDto)
        {
            var response = new BaseResponse<Group>();

            // create after checking success
            var mappedGroup = mapper.Map<Group>(groupDto);

            // save image from dto model to wwwroot

            var result = await unitOfWork.Groups.CreateAsync(mappedGroup);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Group, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist group
            var existGroup = await unitOfWork.Groups.GetAsync(expression);
            if (existGroup is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existGroup.Delete();

            var result = await unitOfWork.Groups.UpdateAsync(existGroup);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Group>>();
            
            var groups = await unitOfWork.Groups.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = groups.ToPagedList(@params);

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Users not found");
            }

            return response;
        }

        public async Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression)
        {
            var response = new BaseResponse<Group>();
            
            var groups = await unitOfWork.Groups.GetAsync(expression);
            if (groups is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = groups;

            return response;
        }

        public async Task<BaseResponse<Group>> UpdateAsync(Guid id, GroupForCreationDto groupDto)
        {
            var response = new BaseResponse<Group>();

            // check for exist student
            var group = await unitOfWork.Groups.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }


            group.Name = groupDto.Name;
            group.TeacherId = groupDto.TeacherId;
            group.CourseId = groupDto.CourseId;
            
            group.Update();

            var result = await unitOfWork.Groups.UpdateAsync(group);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
