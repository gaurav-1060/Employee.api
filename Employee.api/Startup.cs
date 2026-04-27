
using Employee.api.Middlewares;
using Employee.api.Models;
using Employee.api.Repositories;
using Employee.api.Repositories.Interfaces;
using Employee.api.Services;
using Employee.api.Services.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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

            // 🔹 Department
                services.AddScoped<IDepartmentRepository, DepartmentRepository>();
                services.AddScoped<IDepartmentService, DepartmentService>();

                // 🔹 Designation
                services.AddScoped<IDesignationRepository, DesignationRepository>();
                services.AddScoped<IDesignationService, DesignationService>();

                // 🔹 Employee
                services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<IEmployeeService, EmployeeService>();
        }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseMiddleware<ExceptionMiddleware>();

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