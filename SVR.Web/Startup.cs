using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SVR.Core.Repository;
using SVR.Core.Repository.Interface;
using SVR.Core.Services;
using SVR.Core.Services.Interface;
using SVR.Data;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SVR.Web.Adaptors;

namespace SVR.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //for DB connect EF
            services.AddDbContext<AppDataDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // provides helpful error information in the dev environment
            //services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTMzNDYwQDMxMzkyZTMzMmUzME5aNE55aGJmTy9vK0l1MTRWUmNieEI4L01DOEQ0QTJKRi9URnhlMGd2MVU9; NTMzNDYxQDMxMzkyZTMzMmUzMG44SUdhR0NEeTcxN3d6OXYrNjZzZCt3c2EyQmdIQ2g0QzZpYXRMekdsR1U9");

            services.AddScoped<SampleAdaptor>();
            services.AddApplicationLayer();
            services.AddPersistence(Configuration);
            //services.AddTransient<IBillRepository, BillRepository>();
            //services.AddTransient<IBillService, BillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
