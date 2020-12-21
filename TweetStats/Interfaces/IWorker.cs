using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TweetStats.Interfaces
{
    public interface IWorker
    {
        Task PollStream(CancellationToken cancellationToken);
    }
}
