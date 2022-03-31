using System;
using System.Threading.Tasks;

namespace TestEducationCenterUoW.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IGroupRepository Groups { get; }
        Task SaveChangesAsync();
    }
}
