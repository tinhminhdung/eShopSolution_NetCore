using System;
using System.Collections.Generic;
using eShopSolution.Application.Catalog.Categories;
using eShopSolution.Application.Catalog.Menus;
using eShopSolution.Application.Catalog.News;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.Common;
using eShopSolution.Application.Interfacestructure.Services;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Constants;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;


namespace eShopSolution.Web
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

            services.AddControllersWithViews();

            services.AddDbContext<EShopDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IStorageService, FileStorageService>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IMenusService, MenusService>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddControllersWithViews();
            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            #if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
            #endif

            // setup ConnectionString query sql Thông qua Dapper
            services.AddTransient<ISroreQueries>(s => new SroreQueries(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute(
                //          name: "MyAreaProducts",
                //          areaName: "Products",
                //          pattern: "Products/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
         name: "MyArea",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
