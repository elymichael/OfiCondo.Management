namespace OfiCondo.Management.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using OfiCondo.Management.Api.Middleware;
    using OfiCondo.Management.Api.Services;
    using OfiCondo.Management.Api.Utility;
    using OfiCondo.Management.Application;
    using OfiCondo.Management.Application.Constants;
    using OfiCondo.Management.Application.Contracts;
    using OfiCondo.Management.Identity;
    using OfiCondo.Management.Infrastructure;
    using OfiCondo.Management.Persistence;
    using System.Collections.Generic;
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
            AddSwagger(services);

            services.AddAplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersistenceServices(Configuration);
            services.AddIdentityServices(Configuration);

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(ApplicationConstants.Open, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(ApplicationConstants.BearearName, new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                            Enter 'Bearer' [space] and then your token in the text input below.
                            Example: 'Bearer 12345abcdef'",
                    Name = ApplicationConstants.Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = ApplicationConstants.BearearName
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = ApplicationConstants.BearearName
                                },
                                Scheme = "oauth2",
                                Name = ApplicationConstants.BearearName,
                                In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc(ApplicationConstants.SwaggerVersion, new OpenApiInfo
                {
                    Version = ApplicationConstants.SwaggerVersion,
                    Title = ApplicationConstants.SwaggerTitle
                });
                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
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
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApplicationConstants.SwaggerTitle);
            });


            app.UseCustomLoggingHandler();

            app.UseCors(ApplicationConstants.Open);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
