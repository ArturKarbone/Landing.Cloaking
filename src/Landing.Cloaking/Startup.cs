using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Landing.Cloacking.Models;
using Landing.Cloacking.Campaigns;
using Landing.Cloacking.Cloaking;
using Landing.Cloacking.BlackLists.Repository;

namespace Landing.Cloacking
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CampaignRepository, CampaignRepository>();

            services.AddScoped<Cloaker, Cloaker>();
            services.AddScoped<BlackList, BlackList>();
            services.AddScoped<BlackListRepository, BlackListRepository>();
            // Add framework services.
            services.AddMvc();

            //services.AddDbContext<LandingCloackingContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("LandingCloackingContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "campaign",
                   template: "campaigns/handle/{id}",
                   defaults: new { controller = "Cloaking", action = "Handle" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Campaigns}/{action=Index}/{id?}");
            });
        }
    }
}
