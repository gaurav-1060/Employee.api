/*
using Employee.api.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.api
{
  
    using Employee.api.Model;
    using Microsoft.EntityFrameworkCore;

    namespace Employee.api
    {


        //var builder = WebApplication.CreateBuilder(args);

        //// Add services to the container.

        //builder.Services.AddControllers();
        //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        //builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EmpCon")));


        //var app = builder.Build();

        //// Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        //app.MapControllers();

        //app.Run();

    }

    */

    using Employee.api.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Hosting;

    namespace Employee.api
    {
        public class Startup
        {
            // ✅ Store configuration here
            public IConfiguration Configuration { get; }

            // ✅ Constructor
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            // ✅ FIXED METHOD
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers();

                services.AddDbContext<EmployeeDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("EmpCon"))
                );

                // Swagger (optional but recommended)
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen();
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseRouting();

                app.UseHttpsRedirection();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }