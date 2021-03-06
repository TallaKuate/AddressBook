using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.API.Gateways.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microservices.API.Gateways
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
           
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "API Gateways", Version = "v1" });
            });
            
            services.AddScoped<IAddressBookService, AddressBookService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<IUserService, UserService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                builder =>
                                {
                                    builder.AllowAnyOrigin();
                                    builder.AllowAnyHeader();
                                    builder.AllowAnyMethod();
                                });
            });

            services.AddControllers()
                        .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "post API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
