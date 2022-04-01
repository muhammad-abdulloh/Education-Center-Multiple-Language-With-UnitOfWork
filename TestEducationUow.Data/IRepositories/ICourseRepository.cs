using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Entities.Courses;

namespace TestEducationUow.Data.IRepositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
    }
}
