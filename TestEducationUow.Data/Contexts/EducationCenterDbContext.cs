using Microsoft.EntityFrameworkCore;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationCenterUoW.Domain.Entities.Departments;
using TestEducationCenterUoW.Domain.Entities.Groups;
using TestEducationCenterUoW.Domain.Entities.Students;
using TestEducationCenterUoW.Domain.Entities.Teachers;
using TestEducationUow.Domain.Entities.Departments;

namespace TestEducationCenterUoW.Data.Contexts
{
    public class EducationCenterDbContext : DbContext
    {
        public EducationCenterDbContext(DbContextOptions<EducationCenterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries {get; set;}
    }
}
