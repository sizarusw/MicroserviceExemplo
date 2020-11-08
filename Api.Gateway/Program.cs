using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api.Gateway
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build().Run();
        }
    }
}
