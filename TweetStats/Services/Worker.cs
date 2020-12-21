using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TweetStats.Data;
using TweetStats.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace TweetStats.Services
{
    public class Worker : IWorker
    {
        #region Private Properties
        private readonly ILogger _logger;
        private HttpClient httpClient;
        private IServiceScopeFactory scopeFactory;
        #endregion

        #region Public Properties
        public IConfiguration Configuration { get; set; }
        #endregion

        #region Constructor
        public Worker(ILogger<Worker> logger, IServiceScopeFactory sFactory, IConfiguration configuration)
        {
            _logger = logger;
            scopeFactory = sFactory;
            Configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task PollStream(CancellationToken cancellationToken)
        {
            httpClient = new HttpClient();
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    const string url = "https://api.twitter.com/2/tweets/sample/stream";
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration["BearerToken"]);
                    httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

                    using var stream = await httpClient.GetStreamAsync(url, cancellationToken);
                    using var streamReader = new StreamReader(stream);
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        _logger.Log(LogLevel.Information,line);
                        //
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                finally
                {
                    _logger.Log(LogLevel.Warning, "Entering Exponential backoff");
                    await Task.Delay(1000 * 5, cancellationToken);
                }
            }
        }
        #endregion
    }
}
