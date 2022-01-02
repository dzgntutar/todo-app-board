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
            IFetchData api1 = new Api1(_boardTaskManager);

            api1.BaseAddress = "http://www.mocky.io/";
            api1.RequestUri = "v2/5d47f24c330000623fa3ebfa";

            StartFetching startFeching = new StartFetching();
            startFeching.AddApi(api1);

            startFeching.Run();

            return Task.CompletedTask;
        }
    }
}
