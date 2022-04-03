using Serilog;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.Repositories;
using TestEducationCenterUoW.Domain.Entities.Teachers;
using TestEducationUow.Data.IRepositories;

namespace TestEducationUow.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EducationCenterDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
