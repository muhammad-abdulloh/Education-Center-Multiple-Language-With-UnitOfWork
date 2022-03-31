using TestEducationCenterUoW.Data.Contexts;
using TestEducationCenterUoW.Data.IRepositories;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace TestEducationCenterUoW.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationCenterDbContext context;
        private readonly ILogger logger;
        private readonly IConfiguration config;

        /// <summary>
        /// Repositories
        /// </summary>
        public IStudentRepository Students { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public UnitOfWork(EducationCenterDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
            this.logger = new LoggerConfiguration()
                .WriteTo.File
                (
                    path: "Logs/logs.txt",
                    outputTemplate: config.GetSection("Serilog:OutputTemplate").Value,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();

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
