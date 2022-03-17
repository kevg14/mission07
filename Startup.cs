using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission07.Models;
using Mission07.Models.ViewModels;

namespace Mission07
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //for mvc pattern
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {

                options.UseSqlite(Configuration["ConnectionStrings:BookDbConnection"]);
            });

            services.AddScoped<IBookProjectRepository, EFBookProjectRepository>();
            services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();

            //enables razor pages
            services.AddRazorPages();

            //in order ad continue shopping we are adding sessions
            services.AddDistributedMemoryCache();
            services.AddSession();

            //personal note:another possible error here
            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            //for wwwroot folder
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //newest endpoint
                endpoints.MapControllerRoute("typePage",
                    "{projectType}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                //newer endpoint
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 });

                //only type endpoint
                endpoints.MapControllerRoute("type",
                    "{projectType}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

            });

        }
    }
}
