using Serilog;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.Repositories;
using TestEducationUow.Data.IRepositories;
using TestEducationUow.Domain.Entities.Departments;

namespace TestEducationUow.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EducationCenterDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
