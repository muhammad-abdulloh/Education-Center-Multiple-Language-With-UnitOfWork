using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.IRepositories;

namespace TestEducationCenterUoW.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationCenterDbContext context;
        private readonly IConfiguration config;
        private readonly ILogger logger;

        /// <summary>
        /// Repositories
        /// </summary>
        public IStudentRepository Students { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public UnitOfWork(EducationCenterDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;


            // Object initializing for repositories
            Students = new StudentRepository(context, logger);
            Groups = new GroupRepository(context, logger);
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
