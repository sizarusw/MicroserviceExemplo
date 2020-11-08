using Api.Cliente.Dominio;
using Api.Cliente.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Cliente
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            application.UseHsts();
            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddNHibernate();
            services.AddControllersWithViews();
            services.AddTransient<IClienteRepository<Cliente>, ClienteDominio>();
        }
    }
}
