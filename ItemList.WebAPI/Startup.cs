using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ItemList.DataAccess;
using ItemList.DataAccess.Context;
using ItemList.DataAccess.Interfaces;
using ItemList.DataAccess.Implementations;
using ItemList.BLL.Interfaces;
using ItemList.BLL.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ItemList.WebAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            // BLL
            services.Add(new ServiceDescriptor(typeof(IItemCreateService), typeof(ItemCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IItemGetService), typeof(ItemGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IItemUpdateService), typeof(ItemUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICategoryGetService), typeof(CategoryGetService), ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IItemDataAccess), typeof(ItemDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICategoryDataAccess), typeof(CategoryDataAccess), ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<ItemDirectoryContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("ItemDirectory")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
