﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Binders;
using Globomantics.Constraints;
using Globomantics.Conventions;
using Globomantics.Filters;
using Globomantics.Middleware;
using Globomantics.Services;
using Globomantics.Theme;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Globomantics
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
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelValidationFilter));
                options.ModelBinderProviders.Insert(0, new SurveyBinderProvider());
                options.Conventions.Add(new APIConvention());
            });
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddSingleton<ILoanService, LoanService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IRateService, RateService>();
            services.Configure<IConfiguration>(Configuration);
            services.Configure<RazorViewEngineOptions>(
                options => options.ViewLocationExpanders.Add(new ThemeExpander())
            );
            services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("tokenCheck", typeof(TokenConstraint));
                options.ConstraintMap.Add("versionCheck", typeof(RouteVersionConstraint));
                }
            );

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
