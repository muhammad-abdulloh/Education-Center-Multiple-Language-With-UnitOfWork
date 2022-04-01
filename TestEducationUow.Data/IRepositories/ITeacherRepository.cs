using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Entities.Teachers;

namespace TestEducationUow.Data.IRepositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
    }
}
