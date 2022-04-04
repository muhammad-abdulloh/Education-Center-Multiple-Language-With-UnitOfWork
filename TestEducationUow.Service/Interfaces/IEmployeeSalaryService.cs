using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Departments;
using TestEducationUow.Service.DTOs.Departaments;

namespace TestEducationUow.Service.Interfaces
{
    public interface IEmployeeSalaryService
    {
        Task<BaseResponse<EmployeeSalary>> CreateAsync(EmployeeSalaryForCreationDto employeeSalaryDto);
        Task<BaseResponse<EmployeeSalary>> GetAsync(Expression<Func<EmployeeSalary, bool>> expression);
        Task<BaseResponse<IEnumerable<EmployeeSalary>>> GetAllAsync(PaginationParams @params, Expression<Func<EmployeeSalary, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<EmployeeSalary, bool>> expression);
        Task<BaseResponse<EmployeeSalary>> UpdateAsync(Guid id, EmployeeSalaryForCreationDto employeeSalaryDto);

    }
}
