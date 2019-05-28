using AspNetSecurity_NoSecurity.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetSecurity_NoSecurity
{
    public class Startup
    {
        private readonly IHostingEnvironment environment;

        public Startup(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //if (!environment.IsDevelopment())
            services.Configure<MvcOptions>(
                options => options.Filters.Add(new RequireHttpsAttribute())
                );

            services.AddSingleton<ConferenceRepo>();
            services.AddSingleton<ProposalRepo>();
            services.AddSingleton<AttendeeRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            loggerFactory.AddConsole();
#pragma warning restore CS0618 // Type or member is obsolete

            app.UseCsp(
                options => options
                .DefaultSources(s => s.Self())
                .StyleSources(s => s.Self().CustomSources("maxcdn.bootstrapcdn.com"))
                .ReportUris(r => r.Uris("/report"))
            );

            app.UseXfo(o => o.Deny());

            if (!environment.IsDevelopment())
                app.UseHsts(h => h.MaxAge(days: 365).IncludeSubdomains().Preload());


            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseCors(x => x.AllowAnyOrigin());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Conference}/{action=Index}/{id?}");
            });
        }
    }
}
