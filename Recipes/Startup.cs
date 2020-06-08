using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Recipes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:Recipes:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:IdentityDatabase:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            services.AddTransient<IOrdersRepository, EFOrdersRepository>();// andrea
            services.AddTransient<IOrderDetailRepository, EFOrderDetailRepository>();// andrea
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: "AdminPagination",
                    template: "Recipes/{Admin}/Page{recipePage}",
                    defaults: new { Controller = "Admin", action = "Index" });

                routes.MapRoute(
                    name: "pagination",
                    template: "Recipes/{Home}/Page{recipePage}",
                    defaults: new { Controller = "Home", action = "RecipeList" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                // andrea
                routes.MapRoute(
                   name: "Orders",
                   template: "{controller=Orders}/{action=List}/{id?}");

                routes.MapRoute(
                  name: "Customers",
                  template: "{controller=Orders}/{action=ListCustomers}/{id?}");

            });
          
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
