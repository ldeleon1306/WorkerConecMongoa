using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerConecMongo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var client = new MongoClient("mongodb://10.20.2.46:27017/authdb?serverSelectionTimeoutMS=3000&connectTimeoutMS=3000&socketTimeoutMS=3000");
                Console.WriteLine("conecto a mongo 21");
                Console.WriteLine("entra a mongo 22");
                List<string> NombrebaseDatos = client.ListDatabaseNames().ToList();
                Console.WriteLine("entra a mongo 23");
                var database = client.GetDatabase("APIAlmacenes");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
