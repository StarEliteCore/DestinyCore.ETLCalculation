using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Destiny.Core.TaskScheduler.API.Startups;
using Destiny.Core.TaskScheduler.AspNetCore.Middleware;
using Destiny.Core.TaskScheduler.MultiTenancy;
using Destiny.Core.TaskScheduler.Shared.Modules;

namespace Destiny.Core.TaskScheduler.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            //services.AddAppModuleManager<SuktAspNetCoreAppModuleManager>();
            services.AddApplication<SuktAppWebModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMultiTenancy();
            app.UseErrorHandling();
            app.InitializeApplication();
            //app.UseAppModule<SuktAspNetCoreAppModuleManager>();
            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}