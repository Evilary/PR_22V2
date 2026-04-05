using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop_Chernyshkov_Final.Data.DataBase;
using Shop_Chernyshkov_Final.Data.Interfaces;
using Shop_Chernyshkov_Final.Data.Mocks;
using Shop_Chernyshkov_Final.Data.Models;

namespace Shop_Chernyshkov_Final
{
    public class Startup
    {
        public static List<ItemsBasket> ItemsBaskets = new List<ItemsBasket>();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategorys, DBCategorys>();
            services.AddTransient<IItems, DBItems>();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
