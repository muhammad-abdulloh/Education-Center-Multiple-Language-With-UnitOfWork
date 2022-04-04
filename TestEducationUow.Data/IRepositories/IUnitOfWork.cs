using System;
using System.Threading.Tasks;
using TestEducationUow.Data.IRepositories;

namespace TestEducationCenterUoW.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IGroupRepository Groups { get; }
        ITeacherRepository Teachers { get; }
        ICourseRepository Courses { get; }
        IEmployeeRepository Employees { get; }
        IEmployeeSalaryRepository EmployeeSalaries { get; }
        Task SaveChangesAsync();
    }
}
