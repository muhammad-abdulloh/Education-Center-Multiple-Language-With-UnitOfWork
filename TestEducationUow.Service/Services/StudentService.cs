using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Students;
using TestEducationCenterUoW.Service.DTOs.Students;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationCenterUoW.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestEducationCenterUoW.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Student>> CreateAsync(StudentForCreationDto studentDto)
        {
            var response = new BaseResponse<Student>();

            // check for student
            var existStudent = await unitOfWork.Students.GetAsync(p => p.Phone == studentDto.Phone);
            if (existStudent is not null)
            {
                response.Error = new ErrorResponse(400, "User is exist");
                return response;
            }

            // check for group
            var existGroup = await unitOfWork.Groups.GetAsync(p => p.Id == studentDto.GroupId);
            if (existGroup is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            // create after checking success
            var mappedStudent = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Phone = studentDto.Phone,
                GroupId = studentDto.GroupId
            };

            var result = await unitOfWork.Students.CreateAsync(mappedStudent);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist student
            var existStudent = await unitOfWork.Students.GetAsync(expression);
            if (existStudent is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            var result = await unitOfWork.Students.UpdateAsync(existStudent);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Student>>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null)
        {


            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Student>>();

            var students = await unitOfWork.Students.GetAllAsync(expression);

            response.Data = students.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression)
        {
            var response = new BaseResponse<Student>();

            var student = await unitOfWork.Students.GetAsync(expression);
            if (student is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = student;

            return response;
        }

        public async Task<BaseResponse<Student>> UpdateAsync(Guid id, StudentForCreationDto studentDto)
        {
            var response = new BaseResponse<Student>();

            // check for exist student
            var student = await unitOfWork.Students.GetAsync(p => p.Id == id);
            if (student is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            // check for exist group
            var group = await unitOfWork.Groups.GetAsync(p => p.Id == studentDto.GroupId);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            var mappedStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Phone = student.Phone,
                GroupId = student.GroupId
            };
            mappedStudent.Update();

            var result = await unitOfWork.Students.UpdateAsync(mappedStudent);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
