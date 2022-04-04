using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationUow.Domain.Entities.Departments;
using TestEducationUow.Service.DTOs.Departaments;
using TestEducationUow.Service.Interfaces;

namespace TestEducationUow.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }


        public async Task<BaseResponse<Employee>> CreateAsync(EmployeeForCreationDto employeetDto)
        {
            var response = new BaseResponse<Employee>();

            // create after checking success
            var mappedTeacher = mapper.Map<Employee>(employeetDto);

            var result = await unitOfWork.Employees.CreateAsync(mappedTeacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Employee, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist employee
            var existEmployee = await unitOfWork.Employees.GetAsync(expression);
            if (existEmployee is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existEmployee.Delete();

            var result = await unitOfWork.Employees.UpdateAsync(existEmployee);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Employee>>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Employee>>();

            var employees = await unitOfWork.Employees.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = employees.ToPagedList(@params);

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Users not found");
            }

            return response;
        }

        public async Task<BaseResponse<Employee>> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            var response = new BaseResponse<Employee>();

            var employee = await unitOfWork.Employees.GetAsync(expression);
            if (employee is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = employee;

            return response;
        }

        public Task<string> SaveFileAsync(Stream file, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<Employee>> UpdateAsync(Guid id, EmployeeForCreationDto employeeDto)
        {
            var response = new BaseResponse<Employee>();

            // check for exist employee
            var employee = await unitOfWork.Employees.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (employee is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }



            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;
            employee.Phone = employeeDto.Phone;
            employee.Position = employeeDto.Position;
            employee.Update();

            var result = await unitOfWork.Employees.UpdateAsync(employee);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
