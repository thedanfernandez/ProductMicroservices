using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Products.Models;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;

namespace Products.Api
{
    public class Startup
    {

        public IConfiguration Configuration { get; private set; }
        public Startup(IHostingEnvironment env)
        {

            //create configuration source 
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables(); 
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNet5;Trusted_Connection=True;";

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ProductsContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
                
            services.AddTransient<ProductsContext>(t => t.GetService<ProductsContext>());
            //services.AddTransient<IPartsUnlimitedContext>(s => s.GetService<PartsUnlimitedContext>());



            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();



            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }
}
