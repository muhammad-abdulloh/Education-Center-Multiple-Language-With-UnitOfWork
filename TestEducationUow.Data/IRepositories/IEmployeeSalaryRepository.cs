using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Entities.Departments;

namespace TestEducationUow.Data.IRepositories
{
    public interface IEmployeeSalaryRepository : IGenericRepository<EmployeeSalary>
    {
    }
}
