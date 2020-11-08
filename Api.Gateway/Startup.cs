using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Api.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder application)
        {
            application.UseOcelot().Wait();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(Configuration).AddDelegatingHandler<Handler>(true);
        }
    }
}
