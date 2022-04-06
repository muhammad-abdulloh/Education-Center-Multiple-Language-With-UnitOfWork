using Serilog;
using System;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationUow.Data.IRepositories;
using TestEducationUow.Data.Repositories;

#pragma warning disable
namespace TestEducationCenterUoW.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationCenterDbContext context;
        private readonly ILogger logger;

        /// <summary>
        /// Repositories
        /// </summary>
        public IStudentRepository Students { get; set; }

        public IGroupRepository Groups { get; set; }

        public ITeacherRepository Teachers { get; set; }

        public ICourseRepository Courses { get; set; }

        public IEmployeeRepository Employees { get; set; }

        public IEmployeeSalaryRepository EmployeeSalaries { get; set; }

        public UnitOfWork(EducationCenterDbContext context)
        {
            this.context = context;

            // Object initializing for repositories
            Students = new StudentRepository(context, logger);
            Courses = new CourseRepository(context, logger);
            Groups = new GroupRepository(context, logger);
            Teachers = new TeacherRepository(context, logger);
            Employees = new EmployeeRepository(context, logger);
            EmployeeSalaries = new EmployeeSalaryRepository(context, logger);

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
