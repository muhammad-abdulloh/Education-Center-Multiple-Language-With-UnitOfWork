using Serilog;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Entities.Students;

namespace TestEducationCenterUoW.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducationCenterDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }
    }
}
