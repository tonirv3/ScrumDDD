using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ScrumDDD.Domain.Repositories;
using ScrumDDD.Infrastructure.Data;
using ScrumDDD.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using ScrumDDD.Domain;
using ScrumDDD.Infrastructure;
using ScrumDDD.Domain.Commands;
using ScrumDDD.Infrastructure.MessageHandlers;

namespace Scrum.BC.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "API Scrum", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddEntityFrameworkSqlServer().AddDbContext<ScrumDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Scrum.BC.Api"));
             });          
            services.AddControllers();        
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUnitOfWork, ScrumDbContext>(sp=>sp.GetRequiredService<ScrumDbContext>());
            services.AddTransient<IMessageBus, MessageBus>();
            services.AddTransient<IMessageHandler<AddSprintToProjectCommand, bool>, AddSprintToProjecteCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Subscription Scrum v1");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            
        }
    }
}
