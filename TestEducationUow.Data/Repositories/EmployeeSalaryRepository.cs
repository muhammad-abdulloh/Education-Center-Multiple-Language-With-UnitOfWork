using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.Repositories;
using TestEducationCenterUoW.Domain.Entities.Departments;
using TestEducationUow.Data.IRepositories;

namespace TestEducationUow.Data.Repositories
{
    public class EmployeeSalaryRepository : GenericRepository<EmployeeSalary>, IEmployeeSalaryRepository
    {
        public EmployeeSalaryRepository(EducationCenterDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
    
}
