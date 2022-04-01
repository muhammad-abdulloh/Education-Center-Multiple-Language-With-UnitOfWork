using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationUow.Domain.Entities.Departments;

namespace TestEducationUow.Data.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
