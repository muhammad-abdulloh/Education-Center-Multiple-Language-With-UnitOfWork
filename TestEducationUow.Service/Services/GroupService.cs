using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Groups;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationCenterUoW.Service.Helpers;
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

            var teacher = await unitOfWork.Teachers.GetAsync(p => p.Id == groupDto.TeacherId);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "Teacher not found");
                return response;
            }

            var course = await unitOfWork.Courses.GetAsync(p => p.Id == groupDto.CourseId);
            if (course is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            var group = mapper.Map<Group>(groupDto);
            var result = await unitOfWork.Groups.CreateAsync(group);

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
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }
            existGroup.Delete();

            await unitOfWork.Groups.UpdateAsync(existGroup);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {

            var response = new BaseResponse<IEnumerable<Group>>();

            var groups = await unitOfWork.Groups.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = groups.ToPagedList(@params);

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
            }

            return response;
        }

        public async Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression)
        {
            var response = new BaseResponse<Group>();

            var groups = await unitOfWork.Groups.GetAsync(expression);
            if (groups is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            // Language init
            string lang = HttpContextHelper.Language;
            groups.Name = lang == "en" ? groups.NameEn : lang == "ru" ? groups.NameRu : groups.NameUz;
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
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }


            group.NameUz = groupDto.NameUz;
            group.NameRu = groupDto.NameRu;
            group.NameEn = groupDto.NameEn;
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
