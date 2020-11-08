using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Gateway
{
    public class Handler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine(nameof(Handler));
            return base.SendAsync(request, cancellationToken);
        }
    }
}
