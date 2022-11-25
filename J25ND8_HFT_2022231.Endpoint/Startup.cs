using J25ND8_HFT_2022231.Logic;
using J25ND8_HFT_2022231.Logic.Interfaces;
using J25ND8_HFT_2022231.Logic.Services;
using J25ND8_HFT_2022231.Repository.Data;
using J25ND8_HFT_2022231.Repository.Interfaces;
using J25ND8_HFT_2022231.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Endpoint
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
            /* IoC */
            services.AddSingleton<AirPortDbContext>();
            services.AddTransient<IPassengerRepository, PassengerRepository>();
            services.AddTransient<IPlaneRepository, PlaneRepository>();
            services.AddTransient<IAirlineRepository, AirlineRepository>();

            services.AddTransient<IPassengerLogic, PassengerLogic>();
            services.AddTransient<IPlaneLogic, PlaneLogic>();
            services.AddTransient<IAirlineLogic, AirlineLogic>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "J25ND8_HFT_2022231.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "J25ND8_HFT_2022231.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
