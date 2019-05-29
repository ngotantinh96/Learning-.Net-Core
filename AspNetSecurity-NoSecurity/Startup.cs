using AspNetSecurityNoSecurity.Data;
using AspNetSecurityNoSecurity.Repositories;
using AspNetSecurityNoSecurity.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetSecurityNoSecurity
{
    public class Startup
    {
        private readonly IHostingEnvironment environment;
        private readonly IConfiguration config;

        public Startup(IHostingEnvironment environment, IConfiguration config)
        {
            this.environment = environment;
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDataProtection();
            //if (!environment.IsDevelopment())
            services.Configure<MvcOptions>(
                options => options.Filters.Add(new RequireHttpsAttribute())
                );

            services.AddSingleton<ConferenceRepo>();
            services.AddSingleton<ProposalRepo>();
            services.AddSingleton<AttendeeRepo>();
            services.AddSingleton<PurposeStringConstants>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConfArchConnection")));

            services.AddIdentity<ConfArchUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUserClaimsPrincipalFactory<ConfArchUser>, ConfArchUserClaimsPrincipalFactory>();
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

            app.UseAuthentication();

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
