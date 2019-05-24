using System;
using LifetimeDemonstration.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LifetimeDemonstration.Web.Services;
using Microsoft.Extensions.Logging;

namespace LifetimeDemonstration.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<GuidService>();
            //services.AddSingleton<GuidService>();
            services.AddScoped<GuidService>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<CustomMiddleware>();
            
            app.UseMvc();
        }
    }
}
