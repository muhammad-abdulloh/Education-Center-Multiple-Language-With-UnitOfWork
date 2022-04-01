using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.Repositories;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationUow.Data.IRepositories;

namespace TestEducationUow.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(EducationCenterDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
   
}
