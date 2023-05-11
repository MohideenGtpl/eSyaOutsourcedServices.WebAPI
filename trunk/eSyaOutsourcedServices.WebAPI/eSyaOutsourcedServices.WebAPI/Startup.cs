using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaOutsourcedServices.WebAPI.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DL_eSyaOutsourcedServices = eSyaOutsourcedServices.DL.Entities;
using eSyaOutsourcedServices.IF;
using eSyaOutsourcedServices.DL.Repository;
using eSyaOutsourcedServices.DL.Entities;
using Newtonsoft.Json.Serialization;
using eSyaOutsourcedServices.WebAPI.Extention;

namespace eSyaOutsourcedServices.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

           eSyaEnterprise._connString = Configuration.GetConnectionString("dbConn_eSyaEnterprise");

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpAuthAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IOutSourcedVendorRepository, OutSourcedVendorRepository>();
            services.AddScoped<ICommonDataRepository, CommonDataRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes
                    .MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });

            app.UseMvc();
        }
    }
}
