using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Departments;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationUow.Service.DTOs.Departaments;
using TestEducationUow.Service.Interfaces;

namespace TestEducationUow.Service.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeSalaryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<EmployeeSalary>> CreateAsync(EmployeeSalaryForCreationDto employeeSalaryDto)
        {
            var response = new BaseResponse<EmployeeSalary>();

            // create after checking success
            var mappedTeacher = mapper.Map<EmployeeSalary>(employeeSalaryDto);

            var result = await unitOfWork.EmployeeSalaries.CreateAsync(mappedTeacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<EmployeeSalary, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist employeeSalary
            var existEmployeeSalary = await unitOfWork.EmployeeSalaries.GetAsync(expression);
            if (existEmployeeSalary is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existEmployeeSalary.Delete();

            await unitOfWork.EmployeeSalaries.UpdateAsync(existEmployeeSalary);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<EmployeeSalary>>> GetAllAsync(PaginationParams @params, Expression<Func<EmployeeSalary, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<EmployeeSalary>>();

            var employeeSalary = await unitOfWork.EmployeeSalaries.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = employeeSalary.ToPagedList(@params);

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Users not found");
            }

            return response;
        }

        public async Task<BaseResponse<EmployeeSalary>> GetAsync(Expression<Func<EmployeeSalary, bool>> expression)
        {
            var response = new BaseResponse<EmployeeSalary>();

            var employeeSlaary = await unitOfWork.EmployeeSalaries.GetAsync(expression);
            if (employeeSlaary is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = employeeSlaary;

            return response;
        }

        public async Task<BaseResponse<EmployeeSalary>> UpdateAsync(Guid id, EmployeeSalaryForCreationDto employeeSalaryDto)
        {
            var response = new BaseResponse<EmployeeSalary>();

            // check for exist employeeSalary
            var employeeSalary = await unitOfWork.EmployeeSalaries.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (employeeSalary is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }



            employeeSalary.EmployeeId = employeeSalaryDto.EmployeeId;
            employeeSalary.Salary = employeeSalaryDto.Salary;
            employeeSalary.PaymentType = employeeSalaryDto.PaymentType;

            employeeSalary.Update();

            var result = await unitOfWork.EmployeeSalaries.UpdateAsync(employeeSalary);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
