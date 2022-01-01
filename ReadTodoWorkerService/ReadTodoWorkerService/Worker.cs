using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReadTodoWorkerService.Data;
using ReadTodoWorkerService.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReadTodoWorkerService.Entities;

namespace ReadTodoWorkerService
{
    public class Worker : BackgroundService
    {
        IBoardTaskManager _boardTaskManager;

        public Worker(IBoardTaskManager boardTaskManager)
        {
            _boardTaskManager = boardTaskManager;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var task = new BoardTask();
            task.Name = "Task 1";
            task.Level = 1;
            task.EstimatedDuration = 5;

            _boardTaskManager.Add(task);

            var products = _boardTaskManager.GetList();

            Console.WriteLine(products.Count);

            return Task.CompletedTask;
        }
    }
}
