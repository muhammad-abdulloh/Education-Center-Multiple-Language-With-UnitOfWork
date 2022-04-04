using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationUow.Domain.Entities.Departments;
using TestEducationUow.Service.DTOs.Departaments;

namespace TestEducationUow.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<BaseResponse<Employee>> CreateAsync(EmployeeForCreationDto employeeDto);
        Task<BaseResponse<Employee>> GetAsync(Expression<Func<Employee, bool>> expression);
        Task<BaseResponse<IEnumerable<Employee>>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Employee, bool>> expression);
        Task<BaseResponse<Employee>> UpdateAsync(Guid id, EmployeeForCreationDto employeeDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
