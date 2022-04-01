using Serilog;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Entities.Groups;

namespace TestEducationCenterUoW.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(EducationCenterDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }
    }
}
