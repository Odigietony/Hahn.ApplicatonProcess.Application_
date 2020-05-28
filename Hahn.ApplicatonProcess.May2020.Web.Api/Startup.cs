using Hahn.ApplicatonProcess.May2020.Data;
using Hahn.ApplicatonProcess.May2020.Data.IoC;
using Hahn.ApplicatonProcess.May2020.Domain.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace Hahn.ApplicatonProcess.May2020.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }

        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterServices();
            services.AddControllers();
            // @*TODO* ==> uninstall entityframeworkcore SQLServer dependency.
            services.AddDbContext<DataContext>(option =>
            option.UseInMemoryDatabase("ApplicantDb"));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Hahn Applicant Api",
                    Version = "V1",
                    Description = "An api endpoint to handle applicant management.Developed by Anthony for Hahn Softwareentwicklung.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "odigietony.jr@gmail.com",
                        Name = "Odigie Anthony",
                        Url = new Uri("https://github.com/Odigietony")
                    }
                });
                // To include the xml comments in the controllers to the api doc.
                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // Rather than use the absolute path to the xml, dynamically get the path.
                var cmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                options.IncludeXmlComments(cmlCommentFullPath);
            });
            // Register required services
            DependencyContainer.RegisterServices(services);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Hahn Applicant Process Api");
                options.RoutePrefix = "";
            });


            
            app.UseRouting();

            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
