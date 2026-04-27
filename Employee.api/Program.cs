using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Employee.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Information()
                        .WriteTo.Console()
                        .WriteTo.File($"Logs/log_,",
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 3
                         )
                        .CreateLogger();

            try
            {
                Log.Information("Starting the application.");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        // ✅ This connects Startup.cs
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}