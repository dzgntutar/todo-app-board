using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadTodoWorkerService.Data;
using ReadTodoWorkerService.Manager;
using ReadTodoWorkerService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadTodoWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration Configuration = hostContext.Configuration;

                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
                    });

                    services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

                    services.AddSingleton<IBoardTaskManager, BoardTaskManager>();

                    services.AddHostedService<Worker>();
                });
    }
}
