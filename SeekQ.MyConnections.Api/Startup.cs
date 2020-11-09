using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.DependencyInjection;
using App.Common.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeekQ.MyConnections.Api.Application.Queries;
using SeekQ.MyConnections.Api.Infrastructure;

namespace SeekQ.MyConnections.Api
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
            services.AddControllers()
                    .AddFluentValidation(cfg =>
                    {
                        cfg.RegisterValidatorsFromAssemblyContaining<GetBlockedUsersQueryHandler>();
                        cfg.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    });

            services.AddCustomMSSQLDbContext<MyConnectionsDbContext>(Configuration)
                    .AddMediatR(typeof(GetBlockedUsersQueryHandler).Assembly);

            services.AddSwaggerGen(config => {
                config.CustomSchemaIds(x => x.FullName);
                config.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My connections API v1");
                c.RoutePrefix = string.Empty; //Swagger at the  project root URL
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
