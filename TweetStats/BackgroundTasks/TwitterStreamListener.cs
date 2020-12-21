using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TweetStats.Interfaces;

namespace TweetStats.BackgroundTasks
{
    public class TwitterStreamListener : IHostedService
    {
        #region Private Properties
        private readonly ILogger _logger;
        private readonly IWorker _worker;
        private HttpClient httpClient;
        #endregion

        #region Constructor
        public TwitterStreamListener(ILogger<TwitterStreamListener> logger,IWorker worker)
        {
            _logger = logger;
            _worker = worker;
            httpClient = new HttpClient();
        }
        #endregion

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _worker.PollStream(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            httpClient.Dispose();
            return Task.CompletedTask;
        }
    }
}
