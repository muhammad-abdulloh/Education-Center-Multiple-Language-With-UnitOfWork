using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
