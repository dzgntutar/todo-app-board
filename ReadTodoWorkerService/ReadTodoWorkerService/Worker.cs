using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReadTodoWorkerService.FetchData;
using ReadTodoWorkerService.Manager;
using System.Threading;
using System.Threading.Tasks;

namespace ReadTodoWorkerService
{
    public class Worker : BackgroundService
    {
        IBoardTaskManager _boardTaskManager;
        private readonly ILogger<Worker> _logger;

        public Worker(IBoardTaskManager boardTaskManager, ILogger<Worker> logger)
        {
            _logger = logger;
            _boardTaskManager = boardTaskManager;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IFetchData api1 = new Api1(_boardTaskManager)
            {
                BaseAddress = "http://www.mocky.io/",
                RequestUri = "v2/5d47f24c330000623fa3ebfa"
            };

            IFetchData api2 = new Api2(_boardTaskManager)
            {
                BaseAddress = "http://www.mocky.io/",
                RequestUri = "v2/5d47f235330000623fa3ebf7"
            };

            StartFetching startFeching = new StartFetching();
            startFeching.AddApi(api1);
            startFeching.AddApi(api2);

            startFeching.Run();

            return Task.CompletedTask;
        }
    }
}
