using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api.Produto
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build().Run();
        }
    }
}
