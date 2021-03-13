using System;
using System.IO;
using System.Reflection;
using FaceRecognitionDotNet.Server.Data;
using FaceRecognitionDotNet.Server.Services;
using FaceRecognitionDotNet.Server.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FaceRecognitionDotNet.Server
{

    public sealed class Startup
    {

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FaceRecognitionDotNet Server", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(filePath);
            });

            ConfigureApplicationServices(services);

            services.AddDbContext<PostgreSqlDbContext>(options =>
                options.UseNpgsql(this.Configuration.GetConnectionString("PostgreSQLConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FaceRecognitionDotNet Server v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Helpers

        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddTransient<IFaceDetectionService, FaceDetectionService>();
            services.AddTransient<IFaceEncodingService, FaceEncodingService>();
            services.AddTransient<IFaceRegistrationService, FaceRegistrationService>();
        }

        #endregion

        #endregion

    }

}